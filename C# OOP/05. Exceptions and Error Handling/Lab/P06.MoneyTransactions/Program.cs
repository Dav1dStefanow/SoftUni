using System;
using System.Collections.Generic;

namespace P06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,double> accounts = new Dictionary<int,double>();
            string[] accs = Console.ReadLine().Split(',');
            for(int i = 0; i < accs.Length; i++)
            {
                string[] bs = accs[i].Split("-");
                if (!accounts.ContainsKey(int.Parse(bs[0])))
                {
                    accounts[int.Parse(bs[0])] = double.Parse(bs[1]);
                }
            }
            string command;
            while((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ");
                int currAcc = int.Parse(tokens[1]);
                if (tokens[0] == "Deposit")
                {
                    try
                    {
                        if (!accounts.ContainsKey(currAcc))
                        {
                            throw new Exception();
                        }
                        else
                        {
                            accounts[currAcc] += double.Parse(tokens[2]);
                            foreach (var i in accounts)
                            {
                                if (i.Key == currAcc) Console.WriteLine($"Account {i.Key} has new balance: {i.Value}");
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Invalid command!");
                    }
                   
                }
                else if (tokens[0] == "Withdraw")
                {
                    try
                    {
                        if (!accounts.ContainsKey(currAcc))
                        {
                            throw new Exception();
                        }
                        else
                        {
                            foreach (var i in accounts)
                            {
                                if (i.Key == currAcc)
                                {
                                    if(i.Value - double.Parse(tokens[2]) < 0)
                                    {
                                        throw new OverflowException();
                                    }
                                }
                            }
                            accounts[currAcc] -= double.Parse(tokens[2]);
                        }
                    }
                    catch(OverflowException)
                    {
                        Console.WriteLine("Insufficient balance!");
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Invalid command!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
                Console.WriteLine("Enter another command");
            }
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Key} - {account.Value}");
            }
        }
    }
}
