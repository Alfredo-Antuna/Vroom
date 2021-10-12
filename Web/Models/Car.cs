



using System;

namespace Web
{
    public class Car
    {
        public Guid Id {get; set;}
        public ModelEnum Model {get;set;}
        public string Nickname {get;set;}
        public int Year {get;set;}
        public bool IsAvailable {get;set;}
        public int TopSpeed {get;set;}
        public TypeEnum Type {get;set;}
    }   
}