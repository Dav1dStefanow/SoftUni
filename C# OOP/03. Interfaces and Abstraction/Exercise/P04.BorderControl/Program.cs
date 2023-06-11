using System;
using System.Collections.Generic;

namespace P04.BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> list = new List<IIdentifiable>();
            string personInfo;
            while((personInfo = Console.ReadLine()) != "End")
            {
                string[] values = personInfo.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if(values.Length == 2 ) 
                {
                    Robot bot = new Robot(values[0], values[1]);
                    list.Add(bot);
                }
                else if(values.Length == 3 ) 
                {
                    Citizen person = new Citizen(values[0], int.Parse(values[1]), values[2]);
                    list.Add(person);
                }
            }

            string fakeLastDidits = Console.ReadLine();

            foreach(IIdentifiable identifiable in list)
            {
                bool isFake = true;
                int digitPos = 0;
                for(int i = fakeLastDidits.Length - 1; i >= 0; i--)
                {
                    char c = fakeLastDidits[i];
                    char b = identifiable.Id[identifiable.Id.Length - 1 - digitPos];
                    if(c != b)
                    {
                        isFake = false;
                        break;
                    }
                   digitPos++;
                }
                if(isFake)
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }
    }
}
