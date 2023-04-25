using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;

namespace Movies.Models
{
	public class UserModel
	{
		[Key]
		public int UserId { get; set; }

		[Required]
		[StringLength(50)]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[NotMapped]
		[Required]
		[Compare("Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required]
		[StringLength(50)]
		public string Email { get; set; }

		public string SessionId { get; set; }
	}
}