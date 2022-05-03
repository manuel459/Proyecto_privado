using AutoMapper;
using SocialMedia.Core.DTOS;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Post, PostDtos>();
            CreateMap<PostDtos, Post>();
        }
    }
}
