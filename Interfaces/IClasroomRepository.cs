using DTO;

namespace Interfaces
{
    public interface IClassroomRepository
    {
        IEnumerable<Classroom> GetAll();
        void Add(Classroom obj);
        int Update(Classroom obj);
        bool Delete(int id);
        void Save();
        public Classroom? GetById(int id);
    }
}