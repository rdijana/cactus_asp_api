﻿using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogDto, UseCaseLog>();
            CreateMap<UseCaseLog, LogDto>();
        }
    }
}
