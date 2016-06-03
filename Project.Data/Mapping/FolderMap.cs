using System.Data.Entity.ModelConfiguration;

using Project.Model.Models;

namespace Project.Data.Mapping
{
    public class FolderMap : EntityTypeConfiguration<Folder>
    {
        public FolderMap()
        {
            //Primary Key
            HasKey(c => c.Id);

            //Properties


            //Table & Column Mapping
            ToTable("content_folder_tbl");

            Property(c => c.Id).HasColumnName("folder_id");
            Property(c => c.ParentId).HasColumnName("parent_id");
            Property(c => c.Name).HasColumnName("folder_name");
            
            HasOptional(f=>f.Parent)
                .WithMany(f=>f.Children)
                .HasForeignKey(f=>f.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}
