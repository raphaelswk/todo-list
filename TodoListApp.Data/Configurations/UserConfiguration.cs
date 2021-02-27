using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TodoListApp.Entities;

namespace TodoListApp.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // table
            this.ToTable("tb_users");

            // pk
            this.HasKey(p => p.Id);

            // properties
            this.Property(p => p.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.FirstName)
                .HasColumnName("first_name");

            this.Property(p => p.Surname)
                .HasColumnName("surname");

            this.Property(p => p.Login)
                .HasColumnName("login");

            this.Property(p => p.Email)
                .HasColumnName("email");

            this.Property(p => p.ConfirmedEmail)
                .HasColumnName("confirmed_email");

            this.Property(p => p.Phone)
                .HasColumnName("phone");

            this.Property(p => p.ConfirmedPhone)
                .HasColumnName("confirmed_phone");

            this.Property(p => p.Password)
                .HasColumnName("password");

            this.Property(p => p.SecurityStamp)
                .HasColumnName("security_stamp");            
        }
    }
}
