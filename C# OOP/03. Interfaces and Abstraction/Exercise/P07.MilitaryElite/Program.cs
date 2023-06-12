using System;
using System.Collections.Generic;

namespace P07.MilitaryElite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            string input;
            while((input = Console.ReadLine()) != "End") 
            {
                Queue<string> tokens = new Queue<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                if (tokens.Peek() == "Private")
                {
                    tokens.Dequeue();
                    Private @private = new Private(int.Parse(tokens.Dequeue()), tokens.Dequeue(), tokens.Dequeue(), decimal.Parse(tokens.Dequeue()));
                    soldiers.Add(@private);
                }
                else if (tokens.Peek() == "Spy")
                {
                    tokens.Dequeue();
                    Spy spy = new Spy(int.Parse(tokens.Dequeue()), tokens.Dequeue(), tokens.Dequeue(), int.Parse(tokens.Dequeue()));
                    soldiers.Add(@spy);
                }
                else if (tokens.Peek() == "Commando")
                {
                    tokens.Dequeue();
                    Commando commando = new Commando(int.Parse(tokens.Dequeue()), tokens.Dequeue(), tokens.Dequeue(), decimal.Parse(tokens.Dequeue()), tokens.Dequeue());
                    while(tokens.Count > 0)
                    {
                        Mission mission = new Mission(tokens.Dequeue(), tokens.Dequeue());
                        commando.AddMission(mission);
                    }
                    soldiers.Add(@commando);
                }
                else if (tokens.Peek() == "Engineer")
                {
                    tokens.Dequeue();
                    Engineer engineer = new Engineer(int.Parse(tokens.Dequeue()), tokens.Dequeue(), tokens.Dequeue(), decimal.Parse(tokens.Dequeue()), tokens.Dequeue());
                    while( tokens.Count > 0)
                    {
                        Repair repair = new Repair(tokens.Dequeue(), int.Parse(tokens.Dequeue()));
                        engineer.AddRepair(repair);
                    }
                    soldiers.Add(engineer);
                }
                else if (tokens.Peek() == "LieutenantGeneral")
                {
                    tokens.Dequeue();
                    LieutenantGeneral lG = new LieutenantGeneral(int.Parse(tokens.Dequeue()), tokens.Dequeue(), tokens.Dequeue(), decimal.Parse(tokens.Dequeue()));
                    foreach (var s in soldiers)
                    {
                        if (s.Id == int.Parse(tokens.Peek()))
                        {
                            Private p = new Private(s.Id, s.FirstName, s.LastName, s.Salary);
                            lG.AddPrivate(p);
                            tokens.Dequeue();
                        }
                    }
                }
            }
            foreach(var s in soldiers)
            {
                Console.WriteLine(s);
            }
        }
    }
}
