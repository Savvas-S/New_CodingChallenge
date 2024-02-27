using System;
using System.Linq;

namespace Challenge1
{
    public class Unreadable
    {
        public void Do(string element, ref string[] array)
        {
            string[] initialArray = array; //initialize a initialArray as our original Array
            string[] newArray = new string[array.Length - 1]; //create a copy of the original Array with lenght of 1 index less than the original
            int index = 0; //will be used to assign the elemnts to the new array 

            foreach (string item in initialArray) //iterate through each index of the array
            {
                if (item == element) //condition to check if the index is the element we are looking for
                {
                    //if the condition is true then we do nothing and skip the current index
                    continue;
                }
                //otherwise, if the condition is false we assign the index of the original array to the new array 
                newArray[index++] = item;
            }
            Array.Resize(ref newArray, index); //Resizing the new array to remove any null indexes
            array = newArray; //assiging the new array values to the reference "original" array 
        }
    }
}
