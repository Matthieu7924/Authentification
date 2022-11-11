using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AuthMVC.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Path { get; set; }

        [NotMapped]//pour ne pas créer de colonne pour cette propriété
        [Display(Name = "Image")]
        public IFormFile? File { get; set; }

        public int FruitId { get; set; }
        public virtual Fruit? Fruit { get; set; }
    }
}
