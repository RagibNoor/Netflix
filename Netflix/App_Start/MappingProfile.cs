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
            //domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Genre, GenreDto>();



           // Dto to domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(x => x.Id, x => x.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(x => x.Id, x => x.Ignore());
            Mapper.CreateMap<GenreDto, Genre>();
        }
    }
}