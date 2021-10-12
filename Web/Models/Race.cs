using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web
{
    public class Race
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public DateTime Date { get; set; }
        public int BestTime { get; set; } //"bestTime": "{HH:MM:SS}"
        public Guid Winner { get; set; }
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