using System;
using System.Collections.Generic;

namespace Web
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nickname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Car> Cars { get; set; } = new();
        public List<Race> Races { get; set; } = new();
        public int Wins { get; set; }
        public int Losses { get; set; }

        public Driver() { }
        public Driver(DriverDto driverDto)
        {
            Id = new Guid();
            FirstName = driverDto.FirstName;
            LastName = driverDto.LastName;
            Age = driverDto.Age;
            Nickname = driverDto.Nickname;
            DateOfBirth = driverDto.DateOfBirth;
            Wins = driverDto.Wins;
            Losses = driverDto.Losses;

        }
    }
}