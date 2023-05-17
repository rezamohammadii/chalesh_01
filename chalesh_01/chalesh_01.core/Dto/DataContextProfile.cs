using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chalesh_01.core.Dto
{
    public class DataContextProfile : Profile
    {
        public DataContextProfile()
        {
            CreateMap<UserModelIn, UserModelOut>()
            .ReverseMap();
        }
        
    }
}
