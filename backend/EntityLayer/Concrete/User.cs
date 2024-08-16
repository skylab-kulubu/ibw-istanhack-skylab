using System.ComponentModel.DataAnnotations;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete;

public class User : IEntity
{
    [Key]
    public int userId { get; set; }
    [StringLength(30)]
    public string userName { get; set; }
    [StringLength(30)]
    public string password { get; set; }
    [StringLength(50)]
    public string email { get; set; }
    [StringLength(20)]
    public  string userRole { get; set; }
    
    public ICollection<Course> Courses { get; set; }
}