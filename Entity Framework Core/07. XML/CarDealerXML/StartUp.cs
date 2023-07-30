using AutoMapper;
using CarDealerXML.Data;
using CarDealerXML.DTOs.Export;
using CarDealerXML.DTOs.Import;
using CarDealerXML.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace CarDealerXML
{
    internal class StartUp
    {
        private static IMapper mapper;
        static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(db, suppliersXml));
            //Console.WriteLine(ImportParts(db, partsXml));
            //Console.WriteLine(ImportCars(db, carsXml));
            //Console.WriteLine(ImportCustomers(db, customersXml));
            //Console.WriteLine(ImportSales(db, salesXml));

            Console.WriteLine(GetTotalSalesByCustomer(db));
        }
        public static void InsertMapper()
        {
            var config = new MapperConfiguration(mp =>
            {
                mp.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }
        // problem 9
        public static string ImportSuppliers(CarDealerContext db, string inputXml)
        {
            InsertMapper();
            var serializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var supplierXml = new StringReader(inputXml);
            var result = serializer.Deserialize(supplierXml) as SupplierInputModel[];
            var suppliers = mapper.Map<IEnumerable<Supplier>>(result);
            db.AddRange(suppliers);
            db.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
        // problem 10
        public static string ImportParts(CarDealerContext db, string inputXml)
        {
            InsertMapper();
            var serializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            var partsXml = new StringReader(inputXml);
            var result = serializer.Deserialize(partsXml) as PartInputModel[];
            var parts = mapper.Map<IEnumerable<Part>>(result);
            var Parts = parts.Where(s => db.Suppliers.Any(c => c.Id == s.SupplierId));
            db.AddRange(Parts);
            db.SaveChanges();

            return $"Successfully imported {Parts.Count()}";
        }
        // problem 11
        public static string ImportCars(CarDealerContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var carsXml = new StringReader(inputXml);
            var result = serializer.Deserialize(carsXml) as CarInputModel[];
            foreach ( var carXml in result )
            {
                var car = new Car()
                {
                    Make = carXml.Make,
                    Model = carXml.Model,
                    TraveledDistance = carXml.TraveledDistance
                };
                db.Add(car);
                db.SaveChanges();

                foreach (var parts in carXml.Parts )
                {
                    var carPart = new PartCar()
                    {
                        PartId = parts.Id,
                        CarId = car.Id
                    };
                    db.Add(carPart);
                }
            }
            db.SaveChanges();

            return $"Successfully imported {result.Count()}";
        }
        // problem 12
        public static string ImportCustomers(CarDealerContext db, string inputXml)
        {
            InsertMapper();
            var serializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
            var customersXml = new StringReader(inputXml);
            var result = serializer.Deserialize(customersXml) as CustomerInputModel[];
            var customers = mapper.Map<IEnumerable<Customer>>(result);
            db.AddRange(customers);
            db.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }
        // problem 13
        public static string ImportSales(CarDealerContext db, string inputXml)
        {
            InsertMapper();
            var serializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));
            var salesXml = new StringReader(inputXml);
            var result = serializer.Deserialize(salesXml) as SaleInputModel[];
            var sales = mapper.Map<IEnumerable<Sale>>(result);
            var Sales = sales.Where(s => db.Cars.Any(c => c.Id == s.CarId));
            db.AddRange(Sales);
            db.SaveChanges();

            return $"Successfully imported {Sales.Count()}";
        }
        // problem 14
        public static string GetCarsWithDistance(CarDealerContext db)
        {
            const string rootElement = "Cars";
            var cars = db.Cars
                .Where(d => d.TraveledDistance >= 2000000)
                .Select(p => new ExportCarDto
                {
                    Make = p.Make,
                    Model = p.Model,
                    TravelledDistance = p.TraveledDistance,
                })
                .Take(10)
                .OrderBy(m => m.Make)
                .ThenBy(m => m.Model)
                .ToList();
            var result = XMLConverter.Serialize(cars, rootElement);
            return result;
        }
        // problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext db)
        {
            const string rootElement = "cars";
            var cars = db.Cars.Where(m => m.Make == "BMW")
                .Select(p => new ExportCarDto
                {
                    Make = p.Make,
                    Model = p.Model,
                    TravelledDistance = p.TraveledDistance,
                })
                .OrderBy(m => m.Model)
                .ThenByDescending(m => m.TravelledDistance)
                .ToList();
            var result = XMLConverter.Serialize(cars, rootElement);
            return result;
        }
        // problem 16
        public static string GetLocalSuppliers(CarDealerContext db)
        {
            const string rootElement = "suppliers";
            var suppliers = db.Suppliers
                .Where(p => p.IsImporter == false)
                .Select(p => new ExportSupplierDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    PartsCount = p.SupplierParts.Count
                }
                ).ToList();
            var result = XMLConverter.Serialize(suppliers, rootElement);
            return result;
        }
        // problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext db)
        {
            const string rootElement = "cars";
            var cars = db.Cars
                 .Select(x => new ExportCarAndParts
                 {
                     Make = x.Make,
                     Model = x.Model,
                     TravelledDistance = x.TraveledDistance,
                     Parts = x.PartCars.Select(p => new ExportCarPartsDto
                     {
                         Name = p.Part.Name,
                         Price = p.Part.Price
                     })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                 })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();
            var result = XMLConverter.Serialize(cars, rootElement);
            return result;
        }
        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string rootElement = "customers";

            var customers = context.Customers
                .Where(x => x.BoughtCars.Any(s => s.Car != null))
                .Select(x => new ExportCustomer
                {
                    Name = x.Name,
                    BoughtCars = x.BoughtCars.Count(),
                    SpentMoney = x.BoughtCars
                                .SelectMany(s => s.Car.PartCars)
                                .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            string result = XMLConverter.Serialize(customers, rootElement);
            return result;
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string rootElement = "sales";

            var sales = context.Sales
                .Select(x => new SaleExportDto
                {
                    Car = new SaleCar
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TraveledDistance = x.Car.TraveledDistance,
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price)
                    - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100
                })
                .ToList();

            string result = XMLConverter.Serialize(sales, rootElement);

            return result;
        }
    }
}
