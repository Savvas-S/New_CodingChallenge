// RecuirementsController.cs
using Microsoft.AspNetCore.Mvc;
using ProjectDb;

namespace RecuirementsController.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : ControllerBase  //creating a controller for managing requests for Ships
    {
        private readonly ProjectDbContext _dbContext; //constractur for DbContext 
        public ShipController(ProjectDbContext dbContext) { _dbContext = dbContext; }

        [HttpPost] //Request Method
        public IActionResult CreateShip(Ship ship) //method/funciton control  
        {
            try //using try command in case of any errors to catch them later 
            {
                _dbContext.Ship.Add(ship);
                _dbContext.SaveChanges();
                return Ok(ship);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet] //Request Method
        public IActionResult GetShips() //get all ships
        {
            var ships = _dbContext.Ship.ToList();
            return Ok(ships);
        }

    }


    [ApiController]
    [Route("api/[controller]")]
    public class ContainerController : ControllerBase //creating a controller for managing requests for Containers
    {
        private readonly ProjectDbContext _dbContext;
        public ContainerController(ProjectDbContext dbContext) { _dbContext = dbContext; }

        [HttpPost]
        public IActionResult CreateContainer(Container container)
        {
            try
            {
                _dbContext.Container.Add(container);
                _dbContext.SaveChanges();
                return Ok(container);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet] //Request Method
        public IActionResult GetAllContainers() //Get all containers 
        {
            var containers = _dbContext.Container.ToList();
            return Ok(containers);
        }

        [HttpDelete]//Request Method
        public IActionResult DeleteContainer(Container container)
        {
            _dbContext.Container.Remove(container);
            _dbContext.SaveChanges();
            return Ok(container);
        }

    }


    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : ControllerBase
    {

    }

};