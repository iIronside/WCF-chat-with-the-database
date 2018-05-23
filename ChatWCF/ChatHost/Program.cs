﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var host = new ServiceHost(typeof(WCFService.ServiceChat)))
            {
                host.Open();
                //host.
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("Хост стартовал!");
                Console.ReadLine();
                
            }

        }
    }
}
