using DTO;
using Interfaces;
using Repository;

namespace Services
{
    public class ClassroomService : IClasroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly SchoolManagementDbContext _context;
        public ClassroomService(IClassroomRepository classroomRepository, SchoolManagementDbContext context)
        {
            _classroomRepository = classroomRepository;
            _context = context;
        }

        public void CreateClass(Classroom cl)
        {
            try
            {
                _context.Database.BeginTransaction();
                _classroomRepository.Save();
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteClass(int id)
        {
            try
            {
                _context.Database.BeginTransaction();
                var clasroom = _classroomRepository.GetById(id);
                if (clasroom != null)
                {
                    _classroomRepository.Add(clasroom);
                    _classroomRepository.Save();
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

        public IEnumerable<Classroom> GetAllClasses()
        {
            return _classroomRepository.GetAll();
        }

        public void save()
        {
            _classroomRepository.Save();
        }

        public int UpdateClass(Classroom cl)
        {
          return  _classroomRepository.Update(cl);
        }
    }
}