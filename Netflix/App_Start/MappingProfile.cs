using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Netflix.Dto;
using Netflix.Models;

namespace Netflix.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}