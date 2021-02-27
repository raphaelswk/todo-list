using System.Data.Entity.ModelConfiguration;
using TodoListApp.Entities;

namespace TodoListApp.Data.Configurations
{
    public class UserTaskConfiguration : EntityTypeConfiguration<UserTask>
    {
        public UserTaskConfiguration()
        {
            // table
            this.ToTable("tb_tasks");

            // pk
            this.HasKey(p => p.Id);

            // properties
            this.Property(p => p.Id)
                .HasColumnName("id");
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.UserId)
                .HasColumnName("user_id");

            this.Property(p => p.Description)
                .HasColumnName("description");

            this.Property(p => p.Checked)
                .HasColumnName("checked");

            this.Property(p => p.CreatedAt)
                .HasColumnName("created_at");

            this.Property(p => p.ModifiedAt)
                .HasColumnName("modified_at");

            // fks
            this.HasRequired(e => e.User)
                .WithMany(e => e.UserTasks)
                .HasForeignKey(e => e.UserId);
        }
    }
}
