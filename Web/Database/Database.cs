
using Microsoft.EntityFrameworkCore;


namespace Web
{
    public class Database : DbContext 
    {
        DbSet<Car> Cars {get;set;}
        DbSet<Driver> Drivers {get;set;}
        DbSet<Race> Races {get;set;}
        public Database(DbContextOptions<Database> options) : base(options) { }


    }
}