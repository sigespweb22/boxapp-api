using System.Security.Cryptography;
using System;
using AutoMapper;

namespace BoxBack.Application.Extensions
{
    public static class RandomExtensions
    {
        // Summary:
        //     Resolve destination member using a custom value resolver callback. Used instead
        //     of MapFrom when not simply redirecting a source member This method cannot be
        //     used in conjunction with LINQ query projection
        //
        // Parameters:
        //   resolver:
        //     Callback function to resolve against source type
        public static string GenerateIntMaxLength6()
        {
            // Random rnd = new Random(); 
            // int value= rnd.Next(100000,999999);

            Random r = new Random();
            var x = r.Next(0, 1000000);
            string s = x.ToString("000000");
            
            return s;
        }
    }
}