namespace Vasis.Erp.Facil.Shared.Entities.Cadastros;

public class Motorista
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public string? Cnh { get; set; }
    public string? CategoriaCnh { get; set; }
    public DateTime? ValidadeCnh { get; set; }

    public Guid? TransportadoraId { get; set; }
    public Transportadora? Transportadora { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }
}
