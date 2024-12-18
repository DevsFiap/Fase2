using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using TechChallangeFase02.Domain.Entities;
using TechChallangeFase02.Domain.Enums;
using TechChallangeFase02.Infra.Data.Context;
using TechChallangeFase02.Infra.Data.Repository;

namespace TechChallengeFase01.Tests.Repositories
{
    public class ContatoRepositoryTests
    {
        private readonly AppDbContext _contextMock;
        private readonly ContatoRepository _repository;
        private readonly DbSet<Contato> _contatoDbSetMock;

        public ContatoRepositoryTests()
        {
            _contextMock = Substitute.For<AppDbContext>();
            _contatoDbSetMock = Substitute.For<DbSet<Contato>>();
            _contextMock.Set<Contato>().Returns(_contatoDbSetMock);
            _repository = new ContatoRepository(_contextMock);
        }

        [Fact(DisplayName = "Obter por DDD - exceção ao receber DDD invalido")]
        public async Task GetByDDDAsync_Should_Throw_ArgumentException_When_DDD_Is_Invalid()
        {
            // Arrange
            var invalidDdd = (EnumDDD)999;

            // Act
            Func<Task> action = async () => await _repository.GetByDDDAsync(invalidDdd);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>()
                .WithMessage("DDD inválido.*");
        }
    }
}
