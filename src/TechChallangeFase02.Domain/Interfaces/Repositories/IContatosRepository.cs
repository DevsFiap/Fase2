using TechChallangeFase02.Domain.Core;
using TechChallangeFase02.Domain.Entities;
using TechChallangeFase02.Domain.Enums;

namespace TechChallangeFase02.Domain.Interfaces.Repositories;

public interface IContatosRepository : IBaseRepository<Contato>
{
    Task<IEnumerable<Contato>> GetByDDDAsync(EnumDDD ddd);
}