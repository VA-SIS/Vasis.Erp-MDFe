﻿using FluentValidation;
using Vasis.Erp.Facil.Data.Repositories;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;


namespace Vasis.Erp.Facil.Services.Cadastros;

public class EmpresaService 
{
    private readonly IEmpresaRepository _repository;
    private readonly IValidator<Empresa> _validator;

    public EmpresaService(IEmpresaRepository repository, IValidator<Empresa> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<IEnumerable<Empresa>> ListarAsync()
        => await _repository.ObterTodasAsync();

    public async Task<Empresa?> ObterAsync(Guid id)
        => await _repository.ObterPorIdAsync(id);

    public async Task AdicionarAsync(Empresa empresa)
    {
        await _validator.ValidateAndThrowAsync(empresa);
        await _repository.AdicionarAsync(empresa);
    }

    public async Task AtualizarAsync(Empresa empresa)
    {
        await _validator.ValidateAndThrowAsync(empresa);
        await _repository.AtualizarAsync(empresa);
    }

    public async Task ExcluirAsync(Guid id)
        => await _repository.RemoverAsync(id);

    public async Task CriarAsync(Empresa empresa)    
      => await  AdicionarAsync(empresa);

    public async Task ObterPorIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
