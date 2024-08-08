using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapperApp.models.DTOs.Outgoing
{
    public class DriversDto
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public int DriverNumber { get; set; }
        public int WorldChampionships { get; set; }
    }
}