using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;
using FluentValidation;
using Vasis.Erp.Facil.Services.Cadastros;
using Vasis.Erp.Facil.Shared.Validators.Cadastros;
using Vasis.Erp.Facil.Data.Repositories;

namespace Vasis.Erp.Facil.Tests.Services
{
    public class EmpresaServiceTests
    {

        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private IValidator<Empresa> GetValidator()
        {
            return new EmpresaValidator();
        }

        [Fact]
        public async Task Deve_Adicionar_Empresa()
        {
            AppDbContext context = GetDbContext();
            var validator = GetValidator();
            EmpresaService service = new EmpresaService((IEmpresaRepository)context, validator);

            var empresa = new Empresa
            {
                Id = Guid.NewGuid(),
                RazaoSocial = "Empresa Teste",
                NomeFantasia = "Fantasia Teste",
                Cnpj = "12345678000199",
                InscricaoEstadual = "12345678",
                InscricaoMunicipal = "999999",
                Email = "empresa@teste.com",
                Telefone = "11999999999",
                Cep = "01234567",
                Endereco = "Rua Exemplo",
                Numero = "123",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP",
                Ativa = true
            };

             await service.AdicionarAsync(empresa);
            var resultado = await context.Empresas.FirstOrDefaultAsync(e => e.Id == empresa.Id);

            Assert.NotNull(resultado);
            Assert.Equal("Empresa Teste", resultado?.RazaoSocial);
        }

        [Fact]
        public async Task Deve_Listar_Empresas()
        {
            var context = GetDbContext();
            var validator = GetValidator();
            var service = new EmpresaService((IEmpresaRepository)context, validator);

            context.Empresas.Add(new Empresa { Id = Guid.NewGuid(), RazaoSocial = "Empresa 1", NomeFantasia = "Fantasia 1", Cnpj = "123", Estado = "SP" });
            context.Empresas.Add(new Empresa { Id = Guid.NewGuid(), RazaoSocial = "Empresa 2", NomeFantasia = "Fantasia 2", Cnpj = "456", Estado = "SP" });
            await context.SaveChangesAsync();

            var lista = await service.ListarAsync();

            //Assert.Equal(2, lista.Count);
        }

        [Fact]
        public async Task Deve_Editar_Empresa()
        {
            AppDbContext context = GetDbContext();
            var validator = GetValidator();
            var service = new EmpresaService((IEmpresaRepository)context, validator);

            var empresa = new Empresa { Id = Guid.NewGuid(), RazaoSocial = "Original", NomeFantasia = "NF", Cnpj = "123", Estado = "SP" };
            context.Empresas.Add(empresa);
            await context.SaveChangesAsync();

            empresa.RazaoSocial = "Alterado";
            await service.AtualizarAsync(empresa);

            var atualizado = await context.Empresas.FirstOrDefaultAsync(e => e.Id == empresa.Id);
            Assert.Equal("Alterado", atualizado?.RazaoSocial);
        }

        [Fact]
        public async Task Deve_Excluir_Empresa()
        {
            var context = GetDbContext();
            var validator = GetValidator();
            var service = new EmpresaService((IEmpresaRepository)context, validator);

            var empresa = new Empresa { Id = Guid.NewGuid(), RazaoSocial = "Para Excluir", NomeFantasia = "NF", Cnpj = "789", Estado = "SP" };
            context.Empresas.Add(empresa);
            await context.SaveChangesAsync();

            await service.ExcluirAsync(empresa.Id);
            var excluida = await context.Empresas.FirstOrDefaultAsync(e => e.Id == empresa.Id);

            Assert.Null(excluida);
        }
    }
}
