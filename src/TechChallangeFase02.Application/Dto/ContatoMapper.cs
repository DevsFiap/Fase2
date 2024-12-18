using TechChallangeFase02.Domain.Entities;
using TechChallangeFase02.Domain.Enums;

namespace TechChallangeFase02.Application.Dto;

public static class ContatoMapper
{
    public static Contato ConverterParaContato(AtualizarContatoDto atualizarContatoDto, Contato contatoExistente)
    {
        if (atualizarContatoDto == null)
            throw new ArgumentNullException(nameof(atualizarContatoDto));

        contatoExistente.Nome = atualizarContatoDto.Nome;

        // Formatar e separar o telefone
        if (!string.IsNullOrWhiteSpace(atualizarContatoDto.Telefone))
        {
            var ddd = atualizarContatoDto.Telefone.Substring(0, 2);
            var numeroTelefone = atualizarContatoDto.Telefone.Substring(2);
            contatoExistente.Telefone = numeroTelefone;
            contatoExistente.DDDTelefone = (EnumDDD)int.Parse(ddd);
        }

        contatoExistente.Email = atualizarContatoDto.Email;

        return contatoExistente;
    }
}