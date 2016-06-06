using System.Data.Entity.ModelConfiguration;

using Project.Model.Models;

namespace Project.Data.Mapping
{
    public class ContentsMap : EntityTypeConfiguration<Content>
    {
        public ContentsMap()
        {
            //Primary Key
            //HasKey(c => c.Id);

            //Properties
            

            //Table & Column Mapping
            ToTable("content");
            Property(c => c.Id).HasColumnName("content_id").IsRequired();
            Property(c => c.Title).HasColumnName("content_title");
            Property(c => c.Html).HasColumnName("content_html");
            Property(c => c.Summary).HasColumnName("content_teaser");
            Property(c => c.XmlConfigId).HasColumnName("xml_config_id");
            Property(c => c.FolderId).HasColumnName("folder_id").IsOptional();
            HasOptional(c => c.Folder);
        }
    }
}
