using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapperApp.models
{
    public class Driver
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int DriverNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int Status { get; set; }
        public int WorldChampionships { get; set; }
    }
}