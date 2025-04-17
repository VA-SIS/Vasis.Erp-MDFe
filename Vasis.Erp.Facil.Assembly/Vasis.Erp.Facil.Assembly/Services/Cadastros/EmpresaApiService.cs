
using System.Net.Http.Json;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Assembly.Services.Cadastros;

public class EmpresaApiService
{
    private readonly HttpClient _http;

    public EmpresaApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<EmpresaDto>> GetAllAsync() =>
        await _http.GetFromJsonAsync<IEnumerable<EmpresaDto>>("api/empresa") ?? [];

    public async Task<EmpresaDto?> GetByIdAsync(Guid id) =>
        await _http.GetFromJsonAsync<EmpresaDto>($"api/empresa/{id}");

    public async Task CreateAsync(EmpresaDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/empresa", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(EmpresaDto dto)
    {
        var response = await _http.PutAsJsonAsync($"api/empresa/{dto.Id}", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(Guid id)
    {
        var response = await _http.DeleteAsync($"api/empresa/{id}");
        response.EnsureSuccessStatusCode();
    }
}
