using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Subjects;

namespace UniversityCompetition.SystemControl
{
    public class Engine
    {
        private Controller controller;
        public Engine()
        {
            this.controller = new Controller();
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "Exit")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (tokens[0] == "AddSubject")
                    {
                        Console.WriteLine(controller.AddSubject(tokens[1], tokens[2]));
                    }
                    else if (tokens[0] == "AddUniversity")
                    {
                        List<int> requiredSubjects = new List<int>();

                        string[] roles = tokens[4].Split(",", StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < roles.Length; i++)
                        {
                            ISubject sub = controller.Subjects.Models.First(s => s.Name == roles[i]);
                            requiredSubjects.Add(sub.Id);
                        }
                        Console.WriteLine(controller.AddUniversity(tokens[1], tokens[2], int.Parse(tokens[3]), requiredSubjects));
                    }
                    else if (tokens[0] == "AddStudent")
                    {
                        Console.WriteLine(controller.AddStudent(tokens[1], tokens[2]));
                    }
                    else if (tokens[0] == "TakeExam")
                    {
                        Console.WriteLine(controller.TakeExam(int.Parse(tokens[1]), int.Parse(tokens[2])));
                    }
                    else if (tokens[0] == "ApplyToUniversity")
                    {
                        var name = tokens[1] + " " + tokens[2];
                        Console.WriteLine(controller.ApplyToUniversity(name, tokens[3]));
                    }
                    else if (tokens[0] == "UniversityReport")
                    {
                        Console.WriteLine(controller.UniversityReport(int.Parse(tokens[1])));
                    }
                    else if (tokens[0] == "Print")
                    {
                        foreach (var s in controller.Subjects.Models)
                        {
                            Console.WriteLine(s.Id);
                        }
                        foreach (var s in controller.Students.Models)
                        {
                            Console.WriteLine(s.Id);
                        }
                        foreach (var s in controller.Universities.Models)
                        {
                            Console.WriteLine(s.Id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
