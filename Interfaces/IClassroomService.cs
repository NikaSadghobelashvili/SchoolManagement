using DTO;

namespace Interfaces
{
    public interface IClasroomService
    {
        public void CreateClass(Classroom s);
        public int UpdateClass(Classroom s);
        public bool DeleteClass(int id);
        public IEnumerable<Classroom> GetAllClasses();
        public void save();
    }
}