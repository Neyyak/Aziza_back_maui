using MauiApp2.scr.objects;

namespace MauiApp2.scr.services;

public class StudentService
{
    private List<Student> students;
    
    public StudentService()
    {
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public List<Student> GetStudents()
    {
        return students;
    }
    
    public Student GetStudentById(long id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public Student UpdateStudent(long id, Student student)
    {
        Student existingStudent = GetStudentById(id);
        if (existingStudent != null)
        {
            existingStudent.Surname = student.Surname;
            existingStudent.Name = student.Name;
            existingStudent.Patronymic = student.Patronymic;
            existingStudent.Year = student.Year;
            existingStudent.Group = student.Group;
            existingStudent.Ads = student.Ads;
        }
        return existingStudent;
    }
}