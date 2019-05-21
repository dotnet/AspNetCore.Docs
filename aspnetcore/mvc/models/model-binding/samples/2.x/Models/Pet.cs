﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DataAccess.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Breed { get; set; }
        public string Name { get; set; }

        [Required]
        public PetType PetType { get; set; }
    }

    public enum PetType
    {
        Dog = 0,
        Cat = 1
    }
}
