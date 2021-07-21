using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Required")]
        [Display(Name="User Name")]
        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]

        public string Name { get; set; }

        [EmailAddress]
        [RegularExpression("^[A-Z]{1}[a-z_.-0-9]+@[gmail.com]$")]
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        
        [Column("User_Balance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float Balance { get; set; }


        [ForeignKey("Acc_Id")]
        [NotMapped]         // This property is ignored by the database
        public int AccountId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }


    }
}