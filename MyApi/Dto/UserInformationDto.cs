using System.ComponentModel.DataAnnotations;

namespace MyApi.Dto
{
    /// <summary>
    /// User information data transfer object
    /// </summary>
    public class UserInformationDto
    {
        public int Id { set; get; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 1)]
        public string FullName { set; get; }

        [Phone]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 1)]
        public string PhoneNumber { set; get; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 1)]
        public string Email { set; get; }

        [Required]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 3)]
        public string VerificationCode { get; set; }
    }
}
