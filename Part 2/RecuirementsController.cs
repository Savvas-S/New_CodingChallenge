// RecuirementsController.cs
using Microsoft.AspNetCore.Mvc;
using ProjectDb;
using Microsoft.EntityFrameworkCore;
using services;
namespace RecuirementsController.Controllers
{

    //All Controllers here are not handling any data logic, only methods through the incoming requests and the appropriate resposnes
    //Logic and function are included in the services.cs file  

    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : ControllerBase  //creating a controller for managing requests for Ships
    {
        private readonly ShipServices _shipServices; //constractur for ShipServices 
        public ShipController(ShipServices shipServices) { _shipServices = shipServices; }

        //update Ship's MaxLoad
        [HttpPut] //Update method PUT for load of each ship
        public IActionResult updateShipMaxLoad(Ship ship)
        {
            try
            {
                var updatedShip = _shipServices.update_ship(ship); //calling functino update_ship from services.cs 
                return Ok(ship);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //CreateShip
        [HttpPost] //Request Method to create ships
        public IActionResult CreateShip(Ship ship) //method/funciton control  
        {
            try
            {
                var createShip = _shipServices.create_ship(ship);
                return Ok(ship);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //GetShips
        [HttpGet] //Request Method
        public IActionResult GetShips() //get all ships
        {
            var AllShips = _shipServices.get_Allship();
            return Ok(AllShips);
        }

        //AddContainer_ToShip
        [HttpPost]
        [Route("{shipId}/AddContainer/{ContainerId}")] //custom Route since parameters are needed for this type of method
        public IActionResult AddContainer_ToShip(int shipId, int containerId)
        {
            var container_toShip = _shipServices.addContainer_toShip(shipId, containerId);
            return Ok(container_toShip);
        }
        //transfer Container between Ships
        [HttpPost]
        [Route("{shipId}/TransferContainer/{containerId}/ShipToTransfer/{transfered_shipId}")]
        public IActionResult transferContainer_fromShips(int shipId, int transfered_shipId, int containerId)
        {
            try
            {
                var transfered_container = _shipServices.transferContainer_fromShips(shipId, transfered_shipId, containerId);
                return Ok(transfered_container);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class ContainerController : ControllerBase //creating a controller for managing requests for Containers
    {
        private readonly ContainerServices _containerServices;
        public ContainerController(ContainerServices containerServices) { _containerServices = containerServices; }

        //CreateContainer
        [HttpPost]
        public IActionResult CreateContainer([FromBody] Container container)
        {
            try
            {
                var new_container = _containerServices.create_container(container);
                return Ok(new_container);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //Update Container
        [HttpPut]
        public IActionResult UpdateContainer(Container container)
        {
            try
            {
                var updated_container = _containerServices.update_container(container);
                return Ok(updated_container);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //Get All Containers
        [HttpGet] //Request Method
        public IActionResult GetAllContainers() //Get all containers 
        {
            try
            {
                var allContainers = _containerServices.get_allContainers();
                return Ok(allContainers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //Delete Container
        [HttpDelete]//Request Method
        public IActionResult DeleteContainer(Container container)
        {
            try
            {
                var deletedContainer = _containerServices.delete_Container(container);
                return Ok(deletedContainer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly TruckServices _truckServices;
        public TruckController(TruckServices truckServices) { _truckServices = truckServices; }

        //Update Truck
        [HttpPut]
        public IActionResult UpdateTruck([FromBody] Truck truck)
        {
            try
            {
                var updatedTruck = _truckServices.update_truck(truck);
                return Ok(updatedTruck);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        //Create Truck
        [HttpPost] //Request Method
        public IActionResult CreateTruck([FromBody] Truck truck)
        {
            try
            {
                var createdTruck = _truckServices.create_truck(truck);
                return Ok(createdTruck);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //GetAll Trucks
        [HttpGet] //Request Method
        public IActionResult GetAllTrucks() //get all truck
        {
            try
            {
                var allTrucks = _truckServices.getAll_trucks();
                return Ok(allTrucks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //Add Container to Truck
        [HttpPost]
        [Route("{truckId}/AddContainer/{containerId}")]
        public IActionResult AddContainerToTruck(int containerId, int truckId)
        {
            try
            {
                var truck = _truckServices.addContainer_toTruck(containerId, truckId);
                if (truck == null) { return NotFound(); }
                return Ok(truck); // Successfully added container to truck
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Remove last Container
        [HttpPost]
        [Route("{truckId}/RemoveContainer/{containerId}")]
        public IActionResult RemoveLastContainer(int truckId, int containerId)
        {
            try
            {
                var truck = _truckServices.removeLastContainer(truckId, containerId);
                if (truck == null) { return NotFound(); }
                return Ok(truck);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }

};