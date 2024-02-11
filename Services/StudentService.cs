using DTO;
using Interfaces;
using Repository;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly SchoolManagementDbContext _context;
        public StudentService(IStudentRepository studentRepository, SchoolManagementDbContext context)
        {
            _studentRepository = studentRepository;
            _context= context;
        }
        public void CreateStudnet(Student s)
        {
            try
            {
                _context.Database.BeginTransaction();
                _studentRepository.Add(s);
                _studentRepository.Save();
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                _context.Database.BeginTransaction();
                var student = _studentRepository.GetById(id);
                if(student!=null)
                {
                    _studentRepository.Delete(id);
                    _studentRepository.Save();
                    _context.Database.CommitTransaction();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void save()
        {
            _studentRepository.Save();
        }

        public int UpdateStudent(Student s)
        {
          return _studentRepository.Update(s);
        }
    }
}