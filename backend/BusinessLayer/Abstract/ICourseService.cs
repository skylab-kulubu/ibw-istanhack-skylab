using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface ICourseService : IGenericService<Course>
{
    IDataResult<Course> GetCourseByName(string courseName);
}