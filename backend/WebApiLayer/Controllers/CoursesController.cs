using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    [HttpGet("getAllCourses")]
    public IActionResult GetAllCourses()
    {
        var result = courseService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }

        return Ok(result);
    }

    [HttpGet("getById/{id}")]
    public IActionResult GetCourseById(int id)
    {
        var result = courseService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("addCourse")]
    public IActionResult AddCourse(Course course)
    {
        var result = courseService.Add(course);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("updateCourse/{id}")]
    public IActionResult UpdateCourse(int id, Course course)
    {
        course.courseId = id;
        var result = courseService.Update(course);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpDelete("deleteCourse/{id}")]
    public IActionResult DeleteCourse(int id)
    {
        var result = courseService.Delete(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getCourseByName/{courseName}")]
    public IActionResult GetCourseByName(string courseName)
    {
        var result = courseService.GetCourseByName(courseName);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}