using TechChallangeFase02.Application.Dto;

namespace TechChallengeFase01.Tests.Builders
{
    public class AtualizarContatoDtoBuilder
    {
        private string _telefone = "81999999999";
        private string _nome = "Nome";
        private string _email = "email@email.com";

        public AtualizarContatoDtoBuilder()
        {
        }

        public AtualizarContatoDtoBuilder WithInvalidTelefone()
        {
            _telefone = "999";
            return this;
        }

        public AtualizarContatoDto Build()
        {
            return new AtualizarContatoDto
            {
                Nome = _nome,
                Telefone = _telefone,
                Email = _email
            };
        }
    }
}
