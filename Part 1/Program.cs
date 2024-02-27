using System;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1: What does Unreadable do?
            // Unreadable removes a specific input element from an input array, if element is present
            // It takes as parameters an array and an element string.
            // in the function it creates a new array with 1 index less than the input array and sets a flag to Flase
            // It checks if the element which is provided to the function is present in the array provided
            // If it is not present then it copies the index of input array to the new array created within the function
            // If it is present the it sets the Flag as True it skips that specific index. At the end it returns the new array

            // 2: Refactor it for better readability
            Unreadable unreadable = new Unreadable(); // create a new instance of Unreadable class so we can access the function Do

            // Testing data, the original array as input to the function and the element we want to remove
            string[] originalArray = { "car", "bus", "bike", "train", "car", "airplane" };
            string elementToRemove = "car";

            // Display original array
            Console.WriteLine("Original Array:");
            foreach (string item in originalArray)
            {
                Console.WriteLine(item);
            }

            // Call Do method to remove the element of the original Array
            unreadable.Do(elementToRemove, ref originalArray);

            // Display modified array
            Console.WriteLine("\nArray after removing '" + elementToRemove + "':");
            foreach (string item in originalArray)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
