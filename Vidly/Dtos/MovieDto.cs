using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public GenreDto Genre { get; set; }
        [Required]
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
        public int NumberInStock { get; set; }
    }
}