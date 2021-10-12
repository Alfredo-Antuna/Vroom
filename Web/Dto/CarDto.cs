using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web
{
    public class CarDto
    {
        [Required]
        public ModelEnum Model { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public int TopSpeed { get; set; }
        [Required]
        public TypeEnum Type { get; set; }
    }
}