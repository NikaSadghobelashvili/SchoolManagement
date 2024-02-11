using DTO;

namespace Interfaces
{
    public interface IStudentService
    {
        public void CreateStudnet(Student s);
        public int UpdateStudent(Student s);
        public bool DeleteStudent(int id);
        public IEnumerable<Student> GetAllStudents();
        public void save();
        public Student? GetStudentById(int id);
    }
}