using System;

public class ContainerRepository
{
    private readonly List<Container> _container = new List<Container>();
    public void addContainer(Container container) { _container.Add(container); }

}

public class ShipRepository
{
    private readonly List<Ship> _ships = new List<Ship>();
    public void Add(Ship ship) { _ships.Add(ship); }
}


public class TruckRepository
{
    private readonly List<Truck> _truck = new List<Truck>();
    public void Add(Truck truck) { _truck.Add(truck)}
}