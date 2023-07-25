using AutoMapper;
using CarDealerDatabase.Data.DTOs;
using CarDealerDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerDatabase.Data
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile() 
        { 
            this.CreateMap<CarInputModel, Car>();
            this.CreateMap<CustomerInputModel, Customer>();
            this.CreateMap<SaleInputModel, Sale>();
            this.CreateMap<PartInputModel, Part>();
            this.CreateMap<SupplierInputModel, Supplier>();
        }
    }
}
