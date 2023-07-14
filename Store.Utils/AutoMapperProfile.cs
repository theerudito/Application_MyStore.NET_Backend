using AutoMapper;
using Store.DTO;
using Store.Models;

namespace Store.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MAuthDTO, MAuth>();
            CreateMap<MClientsDTO, MClients>();
        }
    }
}
