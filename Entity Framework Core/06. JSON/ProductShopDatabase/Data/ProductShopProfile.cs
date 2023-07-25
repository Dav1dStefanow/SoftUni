using AutoMapper;
using ProductShopDatabase.Data.Models;
using ProductShopDatabase.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Data
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();
        }
    }
}
