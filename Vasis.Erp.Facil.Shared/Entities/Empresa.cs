using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Entities;

public class Empresa
{
    public Guid Id { get; set; }
    public string RazaoSocial { get; set; } = null!;
    public string NomeFantasia { get; set; } = null!;
    public string Cnpj { get; set; } = null!;
    public string InscricaoEstadual { get; set; } = string.Empty;
    public string InscricaoMunicipal { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public bool Ativa { get; set; } = true;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public ICollection<Pessoa>? Pessoas { get; set; }

}