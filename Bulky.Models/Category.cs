using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } //if we name a property Id than it will be treated as primary key we don't need to use data Anotations
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must bre between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
