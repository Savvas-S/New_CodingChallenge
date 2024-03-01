using Microsoft.AspNetCore.Mvc;
using ProjectDb;
using Microsoft.EntityFrameworkCore;

//In this file is where all the logic happens after the requests get processed by the controller 

namespace services
{
    public class TruckServices //Create a Service class specifically for Truck Services 
    {
        private readonly ProjectDbContext _dbContext; //constractur for DbContext for managing EF
        public TruckServices(ProjectDbContext dbContext) { _dbContext = dbContext; }

        //create truck function
        public Truck create_truck(Truck truck) //parameters are object Truck which comes from the request Body
        {
            _dbContext.Truck.Add(truck); //add the new object truck to the database 
            _dbContext.SaveChanges(); //save changes and retur the object 
            return (truck);
        }

        //update_truck function
        public Truck update_truck(Truck truck)
        {
            _dbContext.Truck.Update(truck);
            _dbContext.SaveChanges();
            return (truck);
        }

        //get all trucks from the databse function
        public List<Truck> getAll_trucks() //since Trucks are a LIST object in the Model we use LIST<Truck> to retrieve them
        { return _dbContext.Truck.Include(truck => truck.Containers).ToList(); } //Include is used to bring the associated Containers along with the Trucks

        //Add a container to the Truck
        public Truck addContainer_toTruck(int containerId, int truckId)
        {
            var truck = _dbContext.Truck.Include(truck => truck.Containers).FirstOrDefault(truck => truck.id == truckId); //find the Truck using the id of the Truck
            var container = _dbContext.Container.FirstOrDefault(container => container.id == containerId); //find the container as well using the id of the container
            if (truck == null || container == null) { return null; } // if not found return null (should raise NotFound exception in the controller)
            if (truck.Containers.Any(container => container.id == containerId)) { return null; } //should raise BadRequest exception if container already exists return null
            if (truck.Containers.Count >= truck.maxLoad) { return null; } //should raise BadRequest exception if at maxload, Count counts how many containers are on the Truck
            truck.Containers.Add(container);

            //Remove the container if the container is on any of the Ships since it is added to the Truck
            var ship = _dbContext.Ship.FirstOrDefault(ship => ship.Container.Any(container => container.id == containerId));
            if (ship != null) { ship.Container.Remove(container); }
            _dbContext.SaveChanges();
            return (truck);
        }

        public Truck removeLastContainer(int truckId, int containerId)
        {
            var truck = _dbContext.Truck.Include(truck => truck.Containers).FirstOrDefault(truck => truck.id == truckId);
            if (truck == null) { return null; }
            var lastContainer = truck.Containers.LastOrDefault();
            if (lastContainer == null || lastContainer.id != containerId) { return null; }
            truck.Containers.Remove(lastContainer);
            _dbContext.SaveChanges();

            return truck;
        }
    }

    public class ContainerServices
    {
        private readonly ProjectDbContext _dbContext; // Constructor for DbContext 

        // Corrected constructor
        public ContainerServices(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Container create_container(Container container)
        {
            _dbContext.Container.Add(container);
            _dbContext.SaveChanges();
            return container;
        }

        public Container update_container(Container container)
        {
            _dbContext.Container.Update(container);
            _dbContext.SaveChanges();
            return (container);
        }

        public List<Container> get_allContainers()
        { return _dbContext.Container.ToList(); }

        public Container delete_Container(Container container)
        {
            var deleted_container = _dbContext.Container.Remove(container).Entity;
            _dbContext.SaveChanges();
            return deleted_container;
        }
    }



    public class ShipServices
    {
        private readonly ProjectDbContext _dbContext; // Constructor for DbContext 
        public ShipServices(ProjectDbContext dbContext) { _dbContext = dbContext; }

        public Ship create_ship(Ship ship)
        {
            _dbContext.Ship.Add(ship);
            _dbContext.SaveChanges();
            return (ship);
        }

        public Ship update_ship(Ship ship)
        {
            _dbContext.Ship.Update(ship);
            _dbContext.SaveChanges();
            return (ship);
        }
        public List<Ship> get_Allship()
        {
            var ships = _dbContext.Ship.Include(ship => ship.Container).ToList();
            return (ships);
        }

        public Ship addContainer_toShip(int shipId, int containerId)
        {
            var ship = _dbContext.Ship.Include(ship => ship.Container).FirstOrDefault(ship => ship.id == shipId);
            var container = _dbContext.Container.FirstOrDefault(container => container.id == containerId);
            if (ship == null || container == null) { return null; }
            if (ship.Container.Any(container => container.id == containerId)) { return null; }
            if (ship.Container.Count >= ship.maxLoad) { return null; }
            ship.Container.Add(container);

            var truck = _dbContext.Truck.FirstOrDefault(truck => truck.Containers.Any(container => container.id == containerId));
            if (truck != null) { truck.Containers.Remove(container); }
            _dbContext.SaveChanges();
            return (ship);
        }

        public Ship transferContainer_fromShips(int shipId, int transfered_shipId, int containerId)
        {
            var ship = _dbContext.Ship.Include(ship => ship.Container).FirstOrDefault(ship => ship.id == shipId);
            var ship2 = _dbContext.Ship.Include(ship => ship.Container).FirstOrDefault(ship => ship.id == transfered_shipId);
            var container = _dbContext.Container.FirstOrDefault(container => container.id == containerId);
            if (ship == null || ship2 == null || container == null) { return null; }
            if (ship2.Container.Any(container => container.id == containerId)) { return null; }
            if (ship2.Container.Count >= ship2.maxLoad) { return null; }
            ship.Container.Remove(container);
            ship2.Container.Add(container);
            _dbContext.SaveChanges();
            return (ship2);
        }
    }
}