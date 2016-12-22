namespace WebFormsLab.Model
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  public class Customer
  {
     [Key]
     public int Id { get; set; }

     [Required]
     public string FirstName { get; set; }

     [Required]
     public string LastName { get; set; }

     [Range(0, 130)]
     public int Age { get; set; }

     public Address Address { get; set; }

     [Phone]
     public string DaytimePhone { get; set; }

     [EmailAddress, StringLength(256)]
     public string EmailAddress { get; set; }
  }
}