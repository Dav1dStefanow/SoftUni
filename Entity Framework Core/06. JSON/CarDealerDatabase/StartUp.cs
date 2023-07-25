using AutoMapper;
using CarDealerDatabase.Data;
using CarDealerDatabase.Data.DTOs;
using CarDealerDatabase.Data.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarDealerDatabase
{
    internal class StartUp
    {
        private static IMapper mapper;
        static void Main(string[] args)
        {
            /*
             AutoMapper
             Microsoft.EntityFrameworkCore.SqlServer
             Microsoft.EntityFrameworkCore.Design
             System.Text.Json
            */
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var dtoSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //var dtoParts = File.ReadAllText("../../../Datasets/parts.json");
            //var dtoCars = File.ReadAllText("../../../Datasets/cars.json");
            //var dtoCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //var dtoSales = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(db, dtoSuppliers));
            //Console.WriteLine(ImportParts(db, dtoParts));
            //Console.WriteLine(ImportCars(db, dtoCars));
            //Console.WriteLine(ImportCustomers(db, dtoCustomers));
            //Console.WriteLine(ImportSales(db, dtoSales));

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }
        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }
        // problem 9
        public static string ImportSuppliers(CarDealerContext db, string inputJson)
        {
            InitializeMapper();
            var dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);
            db.Suppliers.AddRange(suppliers);
            db.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
        // proble 10
        public static string ImportParts(CarDealerContext db, string inputJson)
        {
            InitializeMapper();
            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(x => db.Suppliers.Any(a => a.Id == x.SupplierId));
            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);
            db.Parts.AddRange(parts);
            db.SaveChanges();
            return $"Successfully imported {parts.Count()}.";
        }
        // problem 11
        public static string ImportCars(CarDealerContext db, string inputJson)
        {
            InitializeMapper();

            var carsDTOs = JsonConvert
                .DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            foreach (var carDto in carsDTOs)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                db.Cars.Add(car);
                db.SaveChanges();

                foreach (var partId in carDto.PartsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.CarParts.FirstOrDefault(pc => pc.PartId == partId) == null)
                    {
                        db.PartsCars.Add(partCar);
                    }
                }
            }

            db.SaveChanges();

            return $"Successfully imported {carsDTOs.Count()}.";
        }
        // problem 12
        public static string ImportCustomers(CarDealerContext db, string inputJson)
        {
            InitializeMapper();
            var dtoCustomers = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);
            var customers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);
            db.Customers.AddRange(customers);
            db.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        // problem 13
        public static string ImportSales(CarDealerContext db, string inputJson)
        {
            InitializeMapper();
            var dtoSales = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(dtoSales);
            db.Sales.AddRange(sales);
            db.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        // problem 14
        public static string GetOrderedCustomers(CarDealerContext db)
        {
            var query = db.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver);
            string result = JsonConvert.SerializeObject(query, Formatting.Indented);
            return result;
        }
        // problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext db)
        {
            var query = db.Cars
                .Where(m => m.Make == "Toyota")
                .OrderBy(m => m.Model)
                .ThenByDescending(m => m.TraveledDistance);
            string result = JsonConvert.SerializeObject(query, Formatting.Indented);
            return result;
        }
        // problem 16
        public static string GetLocalSuppliers(CarDealerContext db)
        {
            var query = db.Suppliers
                .Where(i => i.IsImporter == false)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    partsCount = p.SupplierParts.Count,
                });
               
            string result = JsonConvert.SerializeObject(query, Formatting.Indented);
            return result;
        }
        // problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext db)
        {
            var query = db.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance,
                    parts = c.CarParts
                    .Select(p => new
                    {
                        p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                });

            string result = JsonConvert.SerializeObject(query, Formatting.Indented);
            return result;
        }
        // problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext db)
        {
            var sales = db.Customers
                .Where(s => s.Buyers.Any(b => b.Car != null))
                    .Select(x => new
                    {
                        fullName = x.Name,
                        boughtCars = x.Buyers.Count,
                        spentMoney = x.Buyers.SelectMany(s => s.Car.CarParts)
                        .Sum(cp => cp.Part.Price)
                    })
                    .OrderByDescending(x => x.spentMoney)
                    .ThenByDescending(x => x.boughtCars)
                    .ToList();

            string result = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return result;
        }
        // problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext db)
        {
            var biggestSales = db.Sales
                .Take(10)
                .Select(c => new
                {
                    Make = c.Car.Make,
                    Model = c.Car.Model,
                    TraveledDistance = c.Car.TraveledDistance,
                    customrtName = c.Customer.Name,
                    discount = $"{c.Discount:F2}",
                    price = c.Car.CarParts.Sum(cp => cp.Part.Price),
                    priceWithDiscount = c.Car.CarParts.Sum(cp => cp.Part.Price) -
                    (c.Car.CarParts.Sum(cp => cp.Part.Price) * c.Discount / 100)
                });
            string result = JsonConvert.SerializeObject(biggestSales, Formatting.Indented);
            return result;
        }
    }
}
