using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShopping.DataAccess.Models
{
    public class User
    {
       
        public int UserId { get; set; }

        //[Required]
        //[StringLength(50)]
        public string? Username { get; set; }
        public string? FullName { get; set; }
        //[Required]
        //[StringLength(255)]
        public string? PasswordHash { get; set; }
        public string? VerificationCode { get; set; }
        public string? JwtToken { get; set; }

        //[Required]
        //[StringLength(100)]
        //[EmailAddress]
        public string? Email { get; set; }

        //[StringLength(255)]
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Zone { get; set; }
        public string? District { get; set; }
        public string? ProfilePicUrl { get; set; }
        public int? RoleId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLogin { get; set; }


    
        //[StringLength(20)]
        public string? PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public string? Dob { get; set; }
        public string?    DateOfBirth { get; set; }


        


        //[Required]

        public List<SelectListItem>? Genderdata { get; set; }
    }
}
