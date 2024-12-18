using TechChallangeFase02.Domain.Entities;
using TechChallangeFase02.Domain.Enums;

namespace TechChallangeFase02.Domain.Interfaces.Services;

public interface IContatoDomainService
{
    Task<List<Contato>> BuscarContatos();
    Task<Contato> GetByIdAsync(int id);
    Task<IEnumerable<Contato>> GetByDDDAsync(EnumDDD ddd);
    Task CreateContatoAsync(Contato contato);
    Task UpdateContatoAsync(int id, Contato contato);
    Task DeleteContatoAsync(int id);
}