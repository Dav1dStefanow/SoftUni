using AutoMapper;
using CarDealerXML.DTOs.Import;
using CarDealerXML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerXML
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile() 
        {
            this.CreateMap<CarInputModel, Car>();
            this.CreateMap<PartInputModel, Part>();
            this.CreateMap<CustomerInputModel, Customer>();
            this.CreateMap<SaleInputModel, Sale>();
            this.CreateMap<SupplierInputModel, Supplier>();
        }
    }
}
