using System;


public class Container
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Ship
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Container> Containers { get; set; } = new List<Container>();
}

public class Truck
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Container> Containers { get; set; } = new List<Container>();

}