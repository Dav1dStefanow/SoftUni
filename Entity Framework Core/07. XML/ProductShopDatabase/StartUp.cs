using AutoMapper;
using ProductShopDatabase.Data;
using ProductShopDatabase.DTOs;
using ProductShopDatabase.Models;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ProductShopDatabase
{
    internal class StartUp
    {
        private static IMapper mapper;
        static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string usersXML = File.ReadAllText(@"..\..\..\Datasets\users.xml");
            //var productsXML = File.ReadAllText(@"..\..\..\Datasets\products.xml");
            //var categoriesXML = File.ReadAllText(@"..\..\..\Datasets\categories.xml");
            //var categoriesproductsXML = File.ReadAllText(@"..\..\..\Datasets\categories-products.xml");

            //Console.WriteLine(ImportUsers(db, usersXML));
            //Console.WriteLine(ImportProducts(db, productsXML));
            //Console.WriteLine(ImportCategories(db, categoriesXML));
            //Console.WriteLine(ImportCategoryProducts(db, categoriesproductsXML));

            Console.WriteLine(GetSoldProducts(db));
        }
        public static void InsertMapping()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
        // problem 1
        public static string ImportUsers(ProductShopContext db, string inputXml)
        {
            InsertMapping();
            var serializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));
            var usersXml = new StringReader(inputXml);
            var result = serializer.Deserialize(usersXml) as UserInputModel[];
            var users = mapper.Map<IEnumerable<User>>(result);
            db.AddRange(users);
            db.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
        // problem 2
        public static string ImportProducts(ProductShopContext db, string inputXml)
        {
            InsertMapping();
            var serializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));
            var productsXml = new StringReader(inputXml);
            var result = serializer.Deserialize(productsXml) as ProductInputModel[];
            var products = mapper.Map<IEnumerable<Product>>(result);
            db.AddRange(products);
            db.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        // problem 3
        public static string ImportCategories(ProductShopContext db, string inputXml)
        {
            InsertMapping();
            var serializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));
            var categoriesXml = new StringReader(inputXml);
            var result = serializer.Deserialize(categoriesXml) as CategoryInputModel[];
            var categories = mapper.Map<IEnumerable<Category>>(result);
            db.AddRange(categories);
            db.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
        // problem 4
        public static string ImportCategoryProducts(ProductShopContext db, string inputXml)
        {
            InsertMapping();
            var serializer = new XmlSerializer(typeof(CategoryProductsInputModel[]), new XmlRootAttribute("CategoryProducts"));
            var categoryProductsXml = new StringReader(inputXml);
            var result = serializer.Deserialize(categoryProductsXml) as CategoryProductsInputModel[];
            var categoryProducts = mapper.Map<IEnumerable<CategoryProducts>>(result);
            db.AddRange(categoryProducts);
            db.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }
        // problem 5
        public static string GetProductsInRange(ProductShopContext db)
        {
            const string rootElement = "Products";

            var top10Products = db.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName,
                })
                .OrderByDescending(x => x.Price)
                .Take(10).ToList();
            var xml = XMLConverter.Serialize(top10Products, rootElement);
            return xml;
        }
        // problem 6
        public static string GetSoldProducts(ProductShopContext db)
        {
            const string rootElement = "Products";
            var users = db.Users
                .Where(x => x.ProductsSold.Any(x => x.BuyerId != null))
                .Select(p => new
                {
                    firstName = p.FirstName,
                    lastName = p.LastName,
                    productsSold = p.ProductsSold
                    .Where(x => x.BuyerId != null)
                    .Select(p => new
                    {
                       name =  p.Name,
                        price = p.Price,
                    }).ToList()
                })
                .OrderBy(f => f.firstName)
                .ThenBy(f => f.lastName)
                .ToList();

            var result = XMLConverter.Serialize(users, rootElement);

            return result;
        }
        // problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";
            var users = context.Categories
                .Select(c => new
                {
                   name = c.Name,
                   count = c.CategoryProducts.Count(),
                   averagePrice =  c.CategoryProducts.Average(p => p.Product.Price),
                   totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(f => f.count)
                .ThenBy(t => t.totalRevenue)
                .ToList();
            var result = XMLConverter.Serialize(users, rootElement);

            return result;
        }
    }
}
