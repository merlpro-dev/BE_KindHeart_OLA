﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_APP.Application.DTO
{
    public class MappingProfile : Profile

    {

        public MappingProfile()

        {

            CreateMap<CreateActivityDto, Activity>();

            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();

            // Add other mappings as needed

        }

    }
}