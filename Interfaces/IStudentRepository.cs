using DTO;

namespace Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        void Add(Student obj);
        int Update(Student obj);
        bool Delete(int id);
        void Save();
    }
}