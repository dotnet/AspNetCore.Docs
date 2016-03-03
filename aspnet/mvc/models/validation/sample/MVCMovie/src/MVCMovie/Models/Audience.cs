using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovie.Models
{
    public enum Audience
    {
       Everyone = 0,
       ParentalGuidance=1,
       ParentalGuidanceUnder13=2,
       RestrictedToAdults=3
    }
}
