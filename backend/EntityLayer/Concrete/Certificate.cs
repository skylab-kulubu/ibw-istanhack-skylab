using System.ComponentModel.DataAnnotations;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete;

public class Certificate : IEntity
{
    [Key]
    public int certificateId { get; set; }
    [StringLength(50)]
    public string name { get; set; }
    [StringLength(200)]
    public string description { get; set; }
    [StringLength(100)]
    public string imageUrl { get; set; }
    public int courseId { get; set; }
    public virtual Course Course { get; set; }
}