using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiCodeChallenge.Common.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, StringLength(30, ErrorMessage = "Address length can't be more than 30.")]
        public string Address { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        public Person(){}
        public Person(string fName, string lName, string address)
        {
            FirstName = fName;
            LastName = lName;
            Address = address;
        }
    }
}
