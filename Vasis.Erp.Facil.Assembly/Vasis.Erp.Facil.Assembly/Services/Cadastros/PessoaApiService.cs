using System.Net.Http.Json;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Frontend.Services.Cadastros;

public class PessoaApiService
{
    private readonly HttpClient _http;

    public PessoaApiService(HttpClient http)
    {
        _http = http;
    }

    private const string Endpoint = "api/pessoas";

    public async Task<List<PessoaDto>?> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<PessoaDto>>(Endpoint);
    }

    public async Task<PessoaDto?> GetByIdAsync(Guid id)
    {
        return await _http.GetFromJsonAsync<PessoaDto>($"{Endpoint}/{id}");
    }

    public async Task<bool> CreateAsync(PessoaDto dto)
    {
        var response = await _http.PostAsJsonAsync(Endpoint, dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Guid id, PessoaDto dto)
    {
        var response = await _http.PutAsJsonAsync($"{Endpoint}/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _http.DeleteAsync($"{Endpoint}/{id}");
        return response.IsSuccessStatusCode;
    }
}
