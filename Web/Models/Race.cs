using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Web
{
    public class Race
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public DateTime Date { get; set; }
        public int BestTime { get; set; } //"bestTime": "{HH:MM:SS}"
        [JsonIgnore]
        public Guid Winner { get; set; }
        [JsonIgnore]
        public List<Driver> Participants { get; set; } = new();

        public Race() { }

        public Race(RaceDto raceDto, List<Driver> participants)
        {
            Name = raceDto.Name;
            Category = raceDto.Category;
            Date = raceDto.Date;
            BestTime = raceDto.BestTime;
            Participants = participants;

        }

    }
}