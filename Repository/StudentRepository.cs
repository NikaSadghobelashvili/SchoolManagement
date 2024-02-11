using DTO;
using Interfaces;

namespace Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolManagementDbContext _context;

        public StudentRepository(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public void Add(Student obj)
        {
            _context.students.Add(obj);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var student = GetById(id);
            if(student!=null)
            {
                _context.students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.students;
        }

        public Student? GetById(int id)
        {
            return _context.students.FirstOrDefault(u => u.StudentId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public int Update(Student obj)
        {
            if (obj != null)
            {
                _context.students.Update(obj);
                _context.SaveChanges();
                return obj.StudentId;
            }
            return -1;
        }
    }
}
