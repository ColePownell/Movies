using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Director
    {


		[Key]
		public int DirectorId { get; set; }


		public string Name { get; set; }


		public string FirstMovie { get; set; }

	}
}
