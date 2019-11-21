using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using ValidationSample.Attributes;

namespace ValidationSample.Models
{
    #region snippet_ModelClass
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [ClassicMovie(1960)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public bool Preorder { get; set; }
    }
    #endregion
}
