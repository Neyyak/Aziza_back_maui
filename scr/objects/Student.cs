namespace MauiApp2.scr.objects;

public class Student
{
    public long Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public int Year { get; set; }
    public int Group { get; set; }
    public List<Ad> Ads { get; set; }

    public Student(long id, string surname, string name, string patronymic, int year, int group, List<Ad> ads)
    {
        Id = id;
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Year = year;
        Group = group;
        Ads = ads;
    }
}
