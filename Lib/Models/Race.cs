


using System;
using System.Collections.Generic;

namespace Lib
{
    public class Race
    {
        public Guid Id {get;set;}
        public string Name {get;set;}
        public CategoryEnum Category {get;set;}
        public DateTime Date {get;set;}
        public string BestTime {get;set;}
        public Driver Driver {get;set;}
        public List<Driver> Participants {get;set;}
    }
}