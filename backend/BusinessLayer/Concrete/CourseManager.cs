using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CourseManager : ICourseService
{
    private readonly ICourseDal _courseDal;

    public CourseManager(ICourseDal courseDal)
    {
        _courseDal = courseDal;
    }

    public IDataResult<Course> GetById(int id)
    {
        var course = _courseDal.GetById(c => c.courseId == id);
        if (course == null)
        {
            return new ErrorDataResult<Course>(CourseMessages.CourseNotFound);
        }

        return new SuccessDataResult<Course>(CourseMessages.CourseBroughtSuccessfully);
    }

    public IDataResult<List<Course>> GetAll()
    {
        var courses = _courseDal.GetAll();
        if (courses.Count == 0)
        {
            return new ErrorDataResult<List<Course>>(CourseMessages.CourseNotFound);
        }

        return new SuccessDataResult<List<Course>>(courses,
            CourseMessages.CoursesBroughtSuccessfully);
    }

    public IResult Add(Course p)
    {
        var courseResult = CheckIfCourseNameExists(p.name);
        if (courseResult.Success)
        {
            return new ErrorResult(courseResult.Message);
        }

        _courseDal.Insert(p);
        return new SuccessResult(CourseMessages.CourseAddedSuccessfully);
    }

    public IResult Update(Course p)
    {
        var courseResult = GetById(p.courseId);
        if (!courseResult.Success)
        {
            return courseResult;
        }

        _courseDal.Update(p);
        return new SuccessResult(CourseMessages.CourseUpdatedSuccessfully);
    }

    public IResult Delete(int id)
    {
        var courseResult = GetById(id);
        if (!courseResult.Success)
        {
            return courseResult;
        }

        _courseDal.Delete(courseResult.Data.courseId);
        return new SuccessResult(CourseMessages.CourseDeletedSuccessfully);
    }

    public IDataResult<Course> GetCourseByName(string courseName)
    {
        var courseResult = CheckIfCourseNameExists(courseName);
        if (!courseResult.Success)
        {
            return new ErrorDataResult<Course>(CourseMessages.CourseNotFound);
        }

        return new SuccessDataResult<Course>(CourseMessages.CourseBroughtSuccessfully);
    }

    private IResult CheckIfCourseExists(int courseId)
    {
        var result = _courseDal.GetById(c => c.courseId == courseId);
        if (result == null)
        {
            return new ErrorResult(CourseMessages.CourseNotFound);
        }

        return new SuccessResult(CourseMessages.CourseAlreadyExists);
    }

    private IResult CheckIfCourseNameExists(string certificateName)
    {
        var result = _courseDal.GetById(c => c.name == certificateName);
        if (result == null)
        {
            return new ErrorResult(CourseMessages.CourseNotFound);
        }

        return new SuccessResult(CourseMessages.NameAlreadyExists);
    }
}