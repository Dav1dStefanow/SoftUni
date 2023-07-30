using AutoMapper;
using ProductShopDatabase.DTOs;
using ProductShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoryProductsInputModel, CategoryProducts>();
        }
    }
}
