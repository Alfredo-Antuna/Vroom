using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web
{
    public class RaceDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public CategoryEnum Category { get; set; }
        [Required]
        [CustomDateAttribute]
        public DateTime Date { get; set; }
        [Required]
        [Range(0, Int32.MaxValue)]
        public int BestTime { get; set; } //"bestTime": "{HH:MM:SS}"
        [Required]
        public Guid Winner { get; set; }
        public List<Guid> ParticipantsIds { get; set; }
    }

    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-2000).ToShortDateString(),
                  DateTime.Now.ToShortDateString())
        { }
    }

}