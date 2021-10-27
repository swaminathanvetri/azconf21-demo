using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
                "https://cosmos-azconf-demo.documents.azure.com:443/",
                "If8vVuDffIJsqRWGQKa3uWmG3ZRT1pdyPnrUPuHFzADUVD2G5mRBkcXgFdYqeY04jpu5i1XAAwtNj5vrEWA7JA==",
                databaseName: "ToDoList", options => {
                    options.Region("West Europe");
                });
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DefaultContainer
            modelBuilder.HasDefaultContainer("Todos");
            #endregion

            #region Container
            modelBuilder.Entity<TodoModel>()
                .ToContainer("Items");
            #endregion

            #region NoDiscriminator
            modelBuilder.Entity<TodoModel>()
                .HasNoDiscriminator();
            #endregion
          }
    }
}