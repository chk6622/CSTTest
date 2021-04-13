using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Entities
{
    /// <summary>
    /// User information model
    /// </summary>
    public class UserInformation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 1)]
        public string FullName { set; get; }

        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 1)]
        public string PhoneNumber { set; get; }

        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 1)]
        public string Email { set; get; }
    }
}
