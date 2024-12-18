using TechChallangeFase02.Application.Dto;
using TechChallangeFase02.Domain.Enums;

namespace TechChallangeFase02.Application.Interfaces;

public interface IContatosAppService
{
    Task<List<ContatoDto>> GetContatos();
    Task<IEnumerable<ContatoDto>> ObterPorDDDAsync(EnumDDD ddd);
    Task<ContatoDto> CriarContatoAsync(CriarContatoDto dto);
    Task<ContatoDto> AtualizarContatoAsync(int id, AtualizarContatoDto dto);
    Task ExcluirContatoAsync(int id);
}