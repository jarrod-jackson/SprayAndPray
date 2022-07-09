using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SprayAndPray.Models
{
    public class Customer
    {
        /// <summary>
        ///     Id: Primary Key and Identity column
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Customer First: Required field
        /// </summary>
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Customer Last: Required field
        /// </summary>
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        ///     Customer Phone Number
        /// </summary>
        [Required]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Customer email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        ///     Customer address
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        ///     Created DateTime
        /// </summary>
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
