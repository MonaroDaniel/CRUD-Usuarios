using CRUD_usuarios.Data.Map;
using CRUD_usuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_usuarios.Data
{
    public class UserCrudDBContext : DbContext
    {
        public UserCrudDBContext(DbContextOptions<UserCrudDBContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
