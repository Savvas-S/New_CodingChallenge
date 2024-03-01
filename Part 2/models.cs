using System;

//Below are defined the Models for the Wev Api
public class Container //Container Model with its properties
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Ship //Ship Model with its properties
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Container> Container { get; set; } = new List<Container>();
    public int maxLoad { get; set; }
}

public class Truck //Tuck Model with its properties
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Container> Containers { get; set; } = new List<Container>();
    public int maxLoad { get; set; }

}