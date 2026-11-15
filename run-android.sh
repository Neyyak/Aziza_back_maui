#!/usr/bin/env zsh
export ANDROID_HOME="${ANDROID_HOME:-$HOME/Library/Android/sdk}"
export PATH="$PATH:$ANDROID_HOME/emulator:$ANDROID_HOME/platform-tools"

# Check if an emulator/device is already running
if ! adb devices | grep -E "emulator-[0-9]+\s+device" >/dev/null 2>&1; then
    echo "Запуск Android эмулятора..."
    AVD=$("$ANDROID_HOME/emulator/emulator" -list-avds | head -n 1)
    if [ -z "$AVD" ]; then
        echo "Ошибка: Не найден ни один Android AVD."
        exit 1
    fi
    echo "Запускаем энергоэффективный AVD: $AVD (30 FPS, Metal, без 3D сцены/аудио)..."
    "$ANDROID_HOME/emulator/emulator" -avd "$AVD" -no-boot-anim -no-audio -camera-back none -camera-front none -vsync-rate 30 >/dev/null 2>&1 &
    echo "Ожидание готовности эмулятора..."
    adb wait-for-device
    while [ "$(adb shell getprop sys.boot_completed 2>/dev/null | tr -d '\r')" != "1" ]; do
        sleep 2
    done
    echo "Эмулятор готов!"
fi

echo "Сборка и запуск приложения на Android..."
dotnet build -t:Run -f net10.0-android
