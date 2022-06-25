using System.ComponentModel.DataAnnotations;

namespace SprayAndPrayWeb.Models
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
        public string FirstName { get; set; }

        /// <summary>
        ///     Customer Last: Required field
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        ///     Customer Phone Number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Customer email
        /// </summary>
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
