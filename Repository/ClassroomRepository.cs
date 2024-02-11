using DTO;
using Interfaces;

namespace Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SchoolManagementDbContext _context;

       public  ClassroomRepository(SchoolManagementDbContext context)
        {
            _context=context;
        }

        public void Add(Classroom obj)
        {
            
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var clasroom = GetById(id);
            if (clasroom != null)
            {
                _context.classrooms.Remove(clasroom);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Classroom> GetAll()
        {
           return _context.classrooms;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public int Update(Classroom obj)
        {
            if (obj != null)
            {
                _context.classrooms.Update(obj);
                _context.SaveChanges();
                return obj.ClassroomId;
            }
            return -1;
        }

        public Classroom? GetById(int id)
        {
            return _context.classrooms.FirstOrDefault(cl => cl.ClassroomId == id);
        }
    }
}
