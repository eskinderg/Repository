using System.Data.Entity.ModelConfiguration;
using Project.Model.Models;

namespace Project.Data.Mapping
{
   public class CategoryMap : EntityTypeConfiguration<Category>
    {
       public CategoryMap()
       {
            //Primary Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Id).HasColumnName("Id").IsRequired();
            Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(c => c.SubCategoryId).HasColumnName("SubCategory_Id").IsOptional();
            HasOptional(c => c.SubCategory);

            //Table & Column Mapping
            ToTable("Categories");

        }
    }
}
