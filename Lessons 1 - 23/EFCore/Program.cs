using EFCore.Models;
using System;
namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _Context = new ApplicationDbContext();

            var category = new Category
            {
                Name = "Films"
            };

            _Context.Categories.Add(category);
            _Context.SaveChanges();
              
        }
    }
}