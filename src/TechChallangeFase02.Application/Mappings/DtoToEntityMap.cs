using AutoMapper;
using TechChallangeFase02.Application.Dto;
using TechChallangeFase02.Domain.Entities;

namespace TechChallangeFase02.Application.Mappings;

public class DtoToEntityMap : Profile
{
    public DtoToEntityMap()
    {
        CreateMap<Contato, ContatoDto>()
            .ForMember(dest => dest.TelefoneFormatado, opt => opt.MapFrom(src => src.Telefone))
            .ForMember(dest => dest.DDDTelefone, opt => opt.MapFrom(src => src.DDDTelefone))
            .ForMember(dest => dest.NumeroTelefone, opt => opt.MapFrom(src => src.Telefone))
            .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.DataCriacao))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
        CreateMap<CriarContatoDto, Contato>().ReverseMap();
        CreateMap<AtualizarContatoDto, Contato>().ReverseMap();
    }
}