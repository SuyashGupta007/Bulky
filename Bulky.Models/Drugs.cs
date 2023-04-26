using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class Drugs
    {
        [Key]
        [DisplayName("Id")]
        public int Batch_Id { get; set; }
        
        
        [Required]
        [DisplayName("Drug Name")]
        public string Drug_Name { get; set; }

        [Required(ErrorMessage = "Quantity should be between 1  to 100")]
        [Range(1, 100)]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "Price cannot be less than 0")]
        [DisplayName("Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // [MyDateValidation(ErrorMessage="Date cannot be earlier than today")]
        public DateOnly Expired_Date{ get; set; }
        
        [Required(ErrorMessage = "Price cannot be less than 0")]
        [Range(1, 200000)]
        public double Price
        { get; set; }

      //  public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
    //    public Category Category { get; set; }
    }

}
