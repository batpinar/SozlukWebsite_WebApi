using AutoMapper;
using BlazorSozluk.Api.Core.Domain.Models;
using BlazorSozluk.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Core.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mapping
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();
            #endregion
        }
    }
}
