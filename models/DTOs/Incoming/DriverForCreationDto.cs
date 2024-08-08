using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapperApp.models.DTOs.Incoming
{
    public class DriverForCreationDto
    {

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int DriverNumber { get; set; }
        public int WorldChampionships { get; set; }
        
    }
}