using AutoMapper;
using Store.DTO;
using Store.Models;

namespace Store.Utils
{
    public class AutoMapperProfile : Profile
    {
        protected AutoMapperProfile()
        {
            CreateMap<MAuthDTO, MAuth>();
            CreateMap<MClientsDTO, MClients>();
        }
    }
}