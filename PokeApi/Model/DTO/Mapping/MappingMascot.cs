using AutoMapper;

namespace PokeApi.Model.DTO.Mapping
{
    public class MappingMascot : Profile
    {
        public MappingMascot()
        {
            CreateMap<Mascot, MascotModel>().ReverseMap();
        }
    }
}