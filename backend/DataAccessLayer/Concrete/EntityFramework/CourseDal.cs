using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;

namespace DataAccessLayer.Concrete.EntityFramework;

public class CourseDal:GenericRepository<Course>,ICourseDal
{
    
}