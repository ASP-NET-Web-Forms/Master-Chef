namespace MasterChef.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Path { get; set; }
    }
}