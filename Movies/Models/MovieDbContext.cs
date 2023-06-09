﻿using Microsoft.EntityFrameworkCore;


namespace Movies.Models
{
	public class MovieDbContext : DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
		{

		}

		public DbSet<UserModel> UserModels { get; set; }

		public DbSet<Director> Directors { get; set; }

		public DbSet<Movie> Movies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserModel>(entity =>
			{
				entity.HasData(new UserModel { UserId = 1, Username = "yifan", Password = "12345", Email = "bianya@mail.uc.edu", ConfirmPassword = "12345" });

			});
			modelBuilder.Entity<Director>(entity =>
			{
				entity.HasData(new Director { DirectorId = 1, FirstMovie = "test movie1", Name = "Test Name1"});
				entity.HasData(new Director { DirectorId = 2, FirstMovie = "test movie2", Name = "Test Name2" });
				entity.HasData(new Director { DirectorId = 3, FirstMovie = "test movie3", Name = "Test Name3" });
			});
			modelBuilder.Entity<Movie>(entity =>
			{
				entity.HasData(new Movie { Id = 1, Description = "Test Movie Description 1", Poster = "\\images\\OIP.jpg", Title = "Test Movie Title 1" });
				entity.HasData(new Movie { Id = 2, Description = "Test Movie Description 2", Poster = "\\images\\OIP.jpg", Title = "Test Movie Title 1" });

			});
		}
	}
}
