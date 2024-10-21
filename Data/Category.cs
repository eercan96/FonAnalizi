using System.ComponentModel.DataAnnotations;

namespace FonAnalizi.Data{
    public class Category{

        [Key]
        public int CategoryId { get; set; }
        public string? Title {get; set;}

        public ICollection<CategorySave> CategorySaves { get; set; } = new List<CategorySave>();

        
    }
}