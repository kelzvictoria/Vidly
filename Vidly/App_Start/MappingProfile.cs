using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            Mapper.CreateMap<MovieDto,Movie>().ForMember(c=>c.Id,opt=>opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}