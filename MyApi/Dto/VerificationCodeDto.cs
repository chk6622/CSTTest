using System.ComponentModel.DataAnnotations;

namespace MyApi.Dto
{
    public class VerificationCodeDto
    {
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 2)]
        public string Code { set; get; }

        [Required(ErrorMessage = "{0} can't be NULL!")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 2)]
        public string Email { set; get; }
    }
}
