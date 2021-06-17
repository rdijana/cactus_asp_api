using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class MarkProfile : Profile
    {
        public MarkProfile()
        {
            CreateMap<Mark, MarkDto>();
            CreateMap<MarkDto, Mark>();
        }
    }
}
