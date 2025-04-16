using AutoMapper;
using Vasis.Erp.Facil.Server.DTOs.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vasis.Erp.Facil.Server.Mappings;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<Empresa, EmpresaDto>().ReverseMap();
    }
}
