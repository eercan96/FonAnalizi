using System.ComponentModel.DataAnnotations;

namespace FonAnalizi.Data{
    public class Fon{

        [Key]
        public int FonId { get; set; }
        public string? FonName { get; set; }
        public string? FonShort { get; set; }
       // public string? Category { get; set; }
       
       [Range(0, double.MaxValue, ErrorMessage = "Fiyat negatif olamaz.")]
        public double Price { get; set; }
        public double? OneDayChange { get; set; }
        public double? OneWeekChange { get; set; }
        public double? OneMonthChange { get; set; }
        public double? ThreeMonthChange { get; set; }
        public double? SixMonthChange { get; set; }
        public double? OneYearChange { get; set; }
        public double? ThreeYearChange { get; set; }
        public double? FiveYearChange { get; set; }

        public ICollection<CategorySave> CategorySaves { get; set; } = new List<CategorySave>();
    }
}