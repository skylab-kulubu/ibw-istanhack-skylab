using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController(ICertificateService certificateService) : ControllerBase
{
    [HttpGet("getAllCertificates")]
    public IActionResult GetAllCertificates()
    {
        var result = certificateService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getById/{id}")]
    public IActionResult GetCertificateById(int id)
    {
        var result = certificateService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("addCertificate")]
    public IActionResult AddCertificate(Certificate certificate)
    {
        var result = certificateService.Add(certificate);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("updateCertificate/{id}")]
    public IActionResult UpdateCertificate(int id, Certificate certificate)
    {
        certificate.certificateId = id;
        var result = certificateService.Update(certificate);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpDelete("deleteCertificate/{id}")]
    public IActionResult DeleteCertificate(int id)
    {
        var result = certificateService.Delete(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getCertificateByName/{name}")]
    public IActionResult GetCertificateByName(string name)
    {
        var result = certificateService.GetCertificateByName(name);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    
    [HttpGet("getCertificateByCourseId/{courseId}")]
    public IActionResult GetCertificateByCourseId(int courseId)
    {
        var result = certificateService.GetCertificateByCourseId(courseId);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}