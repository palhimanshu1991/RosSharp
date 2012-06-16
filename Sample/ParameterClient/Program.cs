﻿using System;
using System.Threading.Tasks;

namespace RosSharp.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //SyncMain();
            AsyncMainTAP();
            //AsyncMain();

            Console.WriteLine("Press Any Key.");
            Console.ReadKey();
            Ros.Dispose();
        }


        static void SyncMain()
        {
            try
            {
                var node = Ros.InitNodeAsync("/ParameterSample").Result;
                var param = node.PrimitiveParameterAsync<string>("/test_param").Result;
                
                param.Subscribe(x => Console.WriteLine(x));
                param.Value = "test";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void AsyncMainTAP()
        {
            Ros.InitNodeAsync("/ParameterSample")
                .ContinueWith(node =>
                {
                    return node.Result.PrimitiveParameterAsync<string>("/test_param");
                })
                .Unwrap()
                .ContinueWith(param =>
                {
                    param.Result.Subscribe(x => Console.WriteLine(x));
                    param.Result.Value = "test";
                })
                .ContinueWith(res =>
                {
                    Console.WriteLine(res.Exception.Message);
                }, TaskContinuationOptions.OnlyOnFaulted);
        }
        /*
        static async void AsyncMain()
        {
            try
            {
                var node = await Ros.InitNodeAsync("/ParameterSample");
                var param = await node.PrimitiveParameterAsync<string>("/test_param");
                
                param.Subscribe(x => Console.WriteLine(x));
                param.Value = "test";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        */
    }
}
