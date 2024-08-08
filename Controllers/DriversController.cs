using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MapperApp.models;
using MapperApp.models.DTOs.Incoming;
using MapperApp.models.DTOs.Outgoing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MapperApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        public static List<Driver> drivers = new List<Driver>();
        private readonly IMapper _mapper;

        public DriversController(ILogger<DriversController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        // GET ALL DRIVERS
        [HttpGet]
        public IActionResult GetDrivers()
        {
            var allDrivers = drivers.Where(x => x.Status == 1).ToList();
            var _drivers = _mapper.Map<IEnumerable<DriversDto>>(allDrivers);
            return Ok(_drivers);
        }

        [HttpPost]
        public IActionResult CreateDriver(DriverForCreationDto data)
        {
            if (ModelState.IsValid)
            {

                var _driver = _mapper.Map<Driver>(data);
                
                drivers.Add(_driver);
                var newDriver = _mapper.Map<DriversDto>(_driver);
                return CreatedAtAction(nameof(GetDriver), new { _driver.Id }, newDriver);
            }

            return new JsonResult("Something Went Wrong") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public IActionResult GetDriver(Guid id)
        {
            var item = drivers.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDriver(Guid id, Driver data)
        {
            if (id != data.Id)
                return BadRequest();

            var existingDriver = drivers.FirstOrDefault(x => x.Id == id);
            if (existingDriver == null)
                return NotFound();

            existingDriver.FirstName = data.FirstName;
            existingDriver.LastName = data.LastName;
            existingDriver.DriverNumber = data.DriverNumber;
            existingDriver.Status = data.Status;
            existingDriver.WorldChampionships = data.WorldChampionships;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(Guid id)
        {
            var existingDriver = drivers.FirstOrDefault(x => x.Id == id);
            if (existingDriver == null)
                return NotFound();

            existingDriver.Status = 0;
            return NoContent();
        }
    }
}
