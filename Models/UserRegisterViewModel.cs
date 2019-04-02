using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApplication.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage="First name field is Required.Must not be null!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name field is Required.Must not be null!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "IBAN field is Required.Must not be null!")]
        public string IBAN { get; set; }

        [Required(ErrorMessage = "Address field is Required.Must not be null!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "BIC field is Required.Must not be null!")]
        [MinLength(10,ErrorMessage ="Min lenght symbols are 10")]
        [MaxLength(15,ErrorMessage ="Max lenght symbols are 15")]
        [StringLength(10,ErrorMessage = "BIC field is Required.Must be 10 symbols!")]
        public string BIC { get; set; }

        [Required(ErrorMessage = "Identification Number field is Required.Must be 10 numbers")]
        //[MinLength(10, ErrorMessage = "Min lenght of ID symbols are 10")]
        //[MaxLength(10, ErrorMessage = "Max lenght of ID symbols are 15")]
       [Range(0000000001,9999999999,ErrorMessage ="ID Number must be 10 numbers")]
        public int IdentificationNumber { get; set; }


    }
}
