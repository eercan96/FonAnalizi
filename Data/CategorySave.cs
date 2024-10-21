using System.ComponentModel.DataAnnotations;

namespace FonAnalizi.Data{

    public class CategorySave{

        [Key]
        public int SaveId { get; set; }
        public int FonId { get; set; }
        public Fon Fon { get; set; } =null!;
        public int CategoryId { get; set; }
        public  Category Category { get; set; } =null!;
    }
}