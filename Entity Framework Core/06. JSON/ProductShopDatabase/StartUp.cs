using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShopDatabase.Data;
using ProductShopDatabase.Data.Models;
using ProductShopDatabase.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProductShopDatabase
{
    internal class StartUp
    {
        private static IMapper mapper;
        static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureCreated();

            //string dtoUsersData = File.ReadAllText("../../../DataSets/users.json");
            //Console.WriteLine(ImportUsers(db, dtoUsersData));
            //string dtoProductsData = File.ReadAllText("../../../DataSets/products.json");
            //Console.WriteLine(ImportProducts(db, dtoProductsData));
            //string dtoCategoriesData = File.ReadAllText("../../../DataSets/categories.json");
            //Console.WriteLine(ImportCategories(db, dtoCategoriesData));
            //string dtoCategoriesProductsData = File.ReadAllText("../../../DataSets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(db, dtoCategoriesProductsData));


            Console.WriteLine(GetUsersWithProducts(db));

        }
        private static void InitializeMapper()
        {
            var config = new MapperConfiguration( c => 
            {
                c.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
        //problem 1
        public static string ImportUsers(ProductShopContext db, string inputJson)
        {
            InitializeMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);
            db.Users.AddRange(users);
            db.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }
        // problem 2
        public static string ImportProducts(ProductShopContext db, string inputJson)
        {
            InitializeMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);
            db.Products.AddRange(products);
            db.SaveChanges();
            return $"Successfully imported {products.Count()}";
        }
        // proble 3
        public static string ImportCategories(ProductShopContext db, string inputJson)
        {
            InitializeMapper() ;

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson);
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);
            db.Categories.AddRange(categories);
            db.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }
        // problem 4
        public static string ImportCategoryProducts(ProductShopContext db, string inputJson)
        {
            InitializeMapper() ;
            var dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);
            db.CategoriesProducts.AddRange(categoriesProducts);
            db.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count()}";
        }
        // problem 5
        public static string GetProductsInRange(ProductShopContext db)
        {
            var products = db.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }
        // problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(p => p.Sellers.Any(b => b.BuyerId != null))
                .Select(p => new
                {
                    firstName = p.FirstName,
                    lastName = p.LastName,
                    soldProducts = p.Sellers
                    .Where(b => b.BuyerId != null)
                    .Select(p => new 
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName,
                    }).ToList(),
                })
                .OrderBy(f => f.firstName)
                .ThenBy(f => f.lastName)
                .ToList();
            var result = JsonConvert.SerializeObject (products, Formatting.Indented);
            return result;
        }
        // problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext db)
        {
            var products = db.Categories
                .Select(p => new
                {
                    name = p.Name,
                    productsCount = p.CategoryProducts.Count,
                    averagePrice = p.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = p.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(f => f.productsCount)
                .ToList();
            string result = JsonConvert.SerializeObject (products, Formatting.Indented) ;
            return result ;
        }
        // problem 8
        public static string GetUsersWithProducts(ProductShopContext db)
        {
            var usersProducts = db.Users
                .Where(s => s.Sellers.Any(s => s.BuyerId != null))
                .Select(u => new 
                { 
                    lastName = u.LastName,
                    age = u.Age,
                    soldProduct = new
                    {
                        count = u.Sellers.Count,
                        products = u.Sellers
                        .Select(s => new 
                        { 
                            name = s.Name,
                            price = s.Price.ToString("F2"),
                        }).ToList()
                    }
                })
                .OrderByDescending(c => c.soldProduct.count)
                .ToList();
            var resulobj = new
            {
                usersCount = usersProducts.Count,
                users = usersProducts
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            string result = JsonConvert.SerializeObject(resulobj, settings);
            return result;
        }
    }
}
