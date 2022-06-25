using System.ComponentModel.DataAnnotations;

namespace SprayAndPrayWeb.Models
{
    public class Category
    {
        /// <summary>
        ///     Id: Primary Key and Identity column
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Name: Required field
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     Display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///     Created DateTime
        /// </summary>
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
