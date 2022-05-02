using System;
using System.Collections.Generic;
using VNBCC2_HFT_2021222.Models;
using ConsoleTools;
namespace VNBCC2_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand's Name: ");
                string name = Console.ReadLine();
                Console.Write("enter BrandId: ");
                int brandId = Convert.ToInt32(Console.ReadLine());
                rest.Post(new Brand() { Name = name, BrandId = brandId}, "brand");
            }
            if (entity == "Guitar")
            {
                Console.Write("Enter Guitar's Base Price: ");
                int basePrice = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Guitar's BrandId: ");
                int brandId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Guitar's release year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Guitar's ShapeId: ");
                int shapeId = Convert.ToInt32(Console.ReadLine());
                rest.Post(new Guitar() { BasePrice = basePrice, BrandId = brandId, Year = year , ShapeId = shapeId}, "guitar");
            }
            if (entity == "Shape")
            {
                Console.Write("Enter Shape's Name: ");
                string name = Console.ReadLine();
                Console.Write("enter ShapeId: ");
                int shapeId = Convert.ToInt32(Console.ReadLine());
                rest.Post(new Shape() { Name = name, ShapeId = shapeId }, "shape");
                rest.Post(new Shape() { Name = name }, "shape");
            }
        }
        static void List(string entity)
        {
            if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("brand");
                foreach (var item in brands)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (entity == "Guitar")
            {
                List<Guitar> guitars = rest.Get<Guitar>("guitar");
                foreach (var item in guitars)
                {
                    Console.WriteLine(item.Brand.Name + ": " + item.Shape.Name);
                }
            }
            else if (entity == "Shape")
            {
                List<Shape> shapes = rest.Get<Shape>("shape");
                foreach (var item in shapes)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity== "Brand")
            {
                Console.Write("Enter Brand's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id, "brand");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "brand");
            }
            if (entity == "Guitar")
            {
                Console.Write("Enter Guitar's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Guitar one = rest.Get<Guitar>(id, "guitar");
                Console.Write($"New name [old: {one.Shape.Name}]: ");
                string name = Console.ReadLine();
                one.Shape.Name = name;
                rest.Put(one, "guitar");
            }
            if (entity == "Shape")
            {
                Console.Write("Enter Shape's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Shape one = rest.Get<Shape>(id, "shape");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "shape");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "brand");
            }
            if (entity == "Guitar")
            {
                Console.Write("Enter Guitar's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "guitar");
            }
            if (entity == "Shape")
            {
                Console.Write("Enter Shape's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "shape");
            }
        }
        static void StatMethods(string entity)
        {

            if (entity == "stat/avgpricebybrands" || entity == "stat/AVGPriceByShapes" || entity == "stat/AllPriceOfGuitarsByBrands")
            {
                var guitars = rest.Get<KeyValuePair<string, double>>(entity);
                foreach (var item in guitars)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }
            else if (entity == "stat/AVGPriceByYears" || entity == "stat/AllPriceByYears")
            {
                var guitars = rest.Get<KeyValuePair<int, double>>(entity);
                foreach (var item in guitars)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }
            else
            {
                throw new ArgumentException("No such Non-CRUD method!");
            }
            Console.ReadLine();
            
        }
            static void Main(string[] args)
        {
            rest = new RestService("http://localhost:48507/");

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);
            
            var nonCrudMethods = new ConsoleMenu(args, level: 1)
                .Add("AVGPriceByBrands", () => StatMethods("stat/avgpricebybrands"))
                .Add("AVGPriceByShapes", () => StatMethods("stat/AVGPriceByShapes"))
                .Add("AllPriceOfGuitarsByBrands", () => StatMethods("stat/AllPriceOfGuitarsByBrands"))
                .Add("AVGPriceByYears", () => StatMethods("stat/AVGPriceByYears"))
                .Add("AllPriceByYears", () => StatMethods("stat/AllPriceByYears"))
                .Add("Exit", ConsoleMenu.Close);

            var guitarSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Guitar"))
                .Add("Create", () => Create("Guitar"))
                .Add("Delete", () => Delete("Guitar"))
                .Add("Update", () => Update("Guitar"))
                .Add("Exit", ConsoleMenu.Close);

            var shapeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Shape"))
                .Add("Create", () => Create("Shape"))
                .Add("Delete", () => Delete("Shape"))
                .Add("Update", () => Update("Shape"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Guitars", () => guitarSubMenu.Show())
                .Add("Shapes", () => shapeSubMenu.Show())
                .Add("Non-CRUD Methods", () => nonCrudMethods.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
