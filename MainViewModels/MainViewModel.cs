using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp2.scr.objects;
using MauiApp2.scr.services;

namespace MauiApp2.MainViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly StudentService _studentService;
    private string _newSurname = string.Empty;
    private string _newName = string.Empty;
    private string _newPatronymic = string.Empty;
    private int _newYear = 1;
    private int _newGroup = 1;
    private string _errorMessage = string.Empty;

    public ObservableCollection<Student> Students { get; set; }

    public string NewSurname
    {
        get => _newSurname;
        set
        {
            _newSurname = value;
            OnPropertyChanged();
        }
    }

    public string NewName
    {
        get => _newName;
        set
        {
            _newName = value;
            OnPropertyChanged();
        }
    }

    public string NewPatronymic
    {
        get => _newPatronymic;
        set
        {
            _newPatronymic = value;
            OnPropertyChanged();
        }
    }

    public int NewYear
    {
        get => _newYear;
        set
        {
            _newYear = value;
            OnPropertyChanged();
        }
    }

    public int NewGroup
    {
        get => _newGroup;
        set
        {
            _newGroup = value;
            OnPropertyChanged();
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddStudentCommand { get; }

    public MainViewModel()
    {
        _studentService = new StudentService();
        Students = new ObservableCollection<Student>(_studentService.GetStudents());
        AddStudentCommand = new Command(AddStudent);
    }

    private void AddStudent()
    {
        if (string.IsNullOrWhiteSpace(NewSurname) || string.IsNullOrWhiteSpace(NewName))
        {
            ErrorMessage = "Surname and Name are required fields!";
            return;
        }

        var newStudent = new Student(
            DateTime.Now.Ticks,
            NewSurname,
            NewName,
            NewPatronymic,
            NewYear,
            NewGroup,
            new List<Ad>()
        );

        _studentService.AddStudent(newStudent);
        Students.Add(newStudent);

        NewSurname = string.Empty;
        NewName = string.Empty;
        NewPatronymic = string.Empty;
        NewYear = 1;
        NewGroup = 1;
        ErrorMessage = string.Empty;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}