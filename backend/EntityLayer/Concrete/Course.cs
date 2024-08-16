using System.ComponentModel.DataAnnotations;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete;

public class Course : IEntity
{
    [Key]
    public int courseId { get; set; }
    [StringLength(50)]
    public string name { get; set; }
    [StringLength(300)]
    public string description { get; set; }
    [StringLength(100)]
    public string imageUrl { get; set; }
    public int userId { get; set; }
    public virtual User User { get; set; }
    public List<Certificate> Certificates { get; set; }
}