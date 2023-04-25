using Microsoft.EntityFrameworkCore;


namespace Movies.Models
{
	public class MovieDbContext : DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
		{

		}

		public DbSet<UserModel> UserModels { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserModel>(entity =>
			{
				entity.HasData(new UserModel { UserId = 1, Username = "yifan", Password = "12345", Email = "bianya@mail.uc.edu", ConfirmPassword = "12345" });

			});
		}
	}
}
