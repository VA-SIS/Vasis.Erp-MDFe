﻿using AutoMapper;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Shared.Dtos.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<Empresa, EmpresaDto>().ReverseMap();
    }
}
