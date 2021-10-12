using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Web
{
    public class DriverDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public List<Car> Cars { get; set; } = new();
        public List<Race> Races { get; set; } = new();
        [Range(0, Int32.MaxValue)]
        public int Wins { get; set; }
        [Range(0, Int32.MaxValue)]
        public int Losses { get; set; }
    }
}