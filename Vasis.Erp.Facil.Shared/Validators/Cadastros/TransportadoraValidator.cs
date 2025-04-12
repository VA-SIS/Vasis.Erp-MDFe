using FluentValidation;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Validators.Cadastros;

public class TransportadoraValidator : AbstractValidator<Transportadora>
{
    public TransportadoraValidator()
    {
        RuleFor(t => t.Nome)
            .NotEmpty().WithMessage("O nome da transportadora é obrigatório.")
            .MaximumLength(200);

        RuleFor(t => t.Cnpj)
            .MaximumLength(20);

        RuleFor(t => t.Uf)
            .MaximumLength(2);
    }
}
