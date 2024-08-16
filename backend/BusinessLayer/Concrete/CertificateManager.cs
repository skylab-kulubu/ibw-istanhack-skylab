using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CertificateManager : ICertificateService
{
    private readonly ICertificateDal _certificateDal;

    public CertificateManager(ICertificateDal certificateDal)
    {
        _certificateDal = certificateDal;
    }

    public IDataResult<Certificate> GetById(int id)
    {
        var certificate = _certificateDal.GetById(c => c.certificateId == id);
        if (certificate == null)
        {
            return new ErrorDataResult<Certificate>(CertificateMessages.CertificateNotFound);
        }

        return new SuccessDataResult<Certificate>(CertificateMessages.CertificateBroughtSuccessfully);
    }

    public IDataResult<List<Certificate>> GetAll()
    {
        var certificates = _certificateDal.GetAll();
        if (certificates.Count == 0)
        {
            return new ErrorDataResult<List<Certificate>>(CertificateMessages.CertificateNotFound);
        }

        return new SuccessDataResult<List<Certificate>>(
            CertificateMessages.CertificateBroughtSuccessfully);
    }

    public IResult Add(Certificate p)
    {
        var certificateResult = CheckIfCertificateExists(p.certificateId);
        if (certificateResult.Success)
        {
            return new ErrorResult(certificateResult.Message);
        }

        _certificateDal.Insert(p);
        return new SuccessResult(CertificateMessages.CertificateAddedSuccessfully);
    }

    public IResult Update(Certificate p)
    {
        var certificateResult = GetById(p.certificateId);
        if (!certificateResult.Success)
        {
            return certificateResult;
        }

        _certificateDal.Update(p);
        return new SuccessResult(CertificateMessages.CertificateUpdatedSuccessfully);
    }

    public IResult Delete(int id)
    {
        var certificateResult = GetById(id);
        if (!certificateResult.Success)
        {
            return certificateResult;
        }

        _certificateDal.Delete(certificateResult.Data.certificateId);
        return new SuccessResult(CertificateMessages.CertificateDeletedSuccessfully);
    }

    public IDataResult<Certificate> GetCertificateByName(string certificateName)
    {
        var certificate = _certificateDal.GetById(c => c.name == certificateName);
        if (certificate == null)
        {
            return new ErrorDataResult<Certificate>(CertificateMessages.CertificateNotFound);
        }

        return new SuccessDataResult<Certificate>(CertificateMessages.CertificateBroughtSuccessfully);
    }

    public IDataResult<Certificate> GetCertificateByCourseId(int courseId)
    {
        
        var certificate = _certificateDal.GetById(c => c.courseId == courseId);
        if (certificate == null)
        {
            return new ErrorDataResult<Certificate>(CertificateMessages.CertificateNotFound);
        }

        return new SuccessDataResult<Certificate>(CertificateMessages.CertificateBroughtSuccessfully);
    }

    private IResult CheckIfCertificateExists(int certificateId)
    {
        var result = _certificateDal.GetById(c => c.certificateId == certificateId);
        if (result == null)
        {
            return new ErrorResult(CertificateMessages.CertificateNotFound);
        }

        return new SuccessResult(CertificateMessages.CertificateAlreadyExists);
    }

    private IResult CheckIfCertificateNameExists(string certificateName)
    {
        var result = _certificateDal.GetById(c => c.name == certificateName);
        if (result == null)
        {
            return new ErrorResult(CertificateMessages.CertificateNotFound);
        }

        return new SuccessResult(CertificateMessages.NameAlreadyExists);
    }
}