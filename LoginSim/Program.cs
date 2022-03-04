using System;
using System.Collections.Generic;

namespace LoginSim
{
    class Program
    {
        static void Main(string[] args)
        {
            bool on = true;
            passmanager psm = new passmanager();
            while (on)
            {
                Console.WriteLine("Register/Login/Information/Quit");
                string answer = Console.ReadLine().ToLower();
                if (answer == "register")
                {
                    Console.WriteLine("Type your preferred name");
                    string regName = Console.ReadLine();
                    Console.WriteLine("Type your password");
                    string regPass = Console.ReadLine();
                    if (psm.checkName(regName))
                    {
                        Console.WriteLine("You have successfully registered");
                        psm.register(regName, regPass);
                        regPass = null;
                    }
                    else
                    {
                        Console.WriteLine("Invalid registration");
                    }
                }
                else if (answer == "login")
                {
                    Console.WriteLine("Type your name");
                    string logName = Console.ReadLine();
                    Console.WriteLine("Type your password");
                    string logPass = Console.ReadLine();
                    if (psm.checkLogin(logName, logPass))
                    {
                        Console.WriteLine("Successfully logged in");
                        logPass = null;
                    }
                    else
                    {
                        Console.WriteLine("Invalid login");
                    }
                }
                else if (answer == "information")
                {
                    psm.showalllogin();
                }
                else if (answer == "quit")
                {
                    on = false;
                }
                else Console.WriteLine("Invalid Input, try again");
            }
        }
    }
    class passmanager
    {
        List<string> username = new List<string>();
        List<string> password = new List<string>();
        public bool checkName(string name)
        {
            if (username.Contains(name))
            {
                return false;
            }
            return true;
        }
        public void register(string name, string pass)
        {
            username.Add(name);
            password.Add(pass);
        }
        public bool checkLogin(string name, string pass)
        {
            if (username.Contains(name))
            {
                if (password[username.IndexOf(name)] == pass)
                {
                    return true;
                }
            }
            return false;
        }
        public void showalllogin()
        {
            for (int i = 0; i < username.Count; i++)
            {
                Console.WriteLine(username[i] + " " + password[i]);
            }
        }
    }
}
