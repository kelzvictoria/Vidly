using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1, 20)]
        [Display(Name ="Number in Stock")]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }

    }
}