using Microsoft.EntityFrameworkCore;
using TechChallangeFase02.Domain.Entities;
using TechChallangeFase02.Domain.Enums;
using TechChallangeFase02.Domain.Interfaces.Repositories;
using TechChallangeFase02.Infra.Data.Context;

namespace TechChallangeFase02.Infra.Data.Repository;

public class ContatoRepository : BaseRepository<Contato>, IContatosRepository
{
    private readonly AppDbContext _context;

    public ContatoRepository(AppDbContext context) : base(context)
        => _context = context;

    public async Task<IEnumerable<Contato>> GetByDDDAsync(EnumDDD ddd)
    {
        if (!Enum.IsDefined(typeof(EnumDDD), ddd))
            throw new ArgumentException("DDD inválido.", nameof(ddd));

        string dddString = ((int)ddd).ToString();

        return await _context.Set<Contato>()
            .Where(c => c.Telefone.StartsWith($"({dddString})"))
            .ToListAsync();
    }
}