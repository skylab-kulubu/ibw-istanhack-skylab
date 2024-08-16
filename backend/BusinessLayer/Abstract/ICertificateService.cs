using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface ICertificateService : IGenericService<Certificate>
{
    IDataResult<Certificate> GetCertificateByName(string certificateName);
    IDataResult<Certificate> GetCertificateByCourseId(int courseId);
}