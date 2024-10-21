using Microsoft.EntityFrameworkCore;

namespace FonAnalizi.Data {

public class DataContext:DbContext{
    public DataContext(DbContextOptions<DataContext>options):base(options){}
    public DbSet<Category>Categories => Set<Category>();
    public DbSet<Fon>Fons => Set<Fon>();
    public DbSet<CategorySave>CategoriesSaves => Set<CategorySave>();
}

}