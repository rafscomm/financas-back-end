﻿using System.Runtime.CompilerServices;
using financas.Models;
using financas.Models.DTO;
using financas.Request;
using financas.Response;
using Microsoft.AspNetCore.Mvc;

namespace financas.Services.Interfaces;

public interface IDespesasService
{
    public Task<IEnumerable<DespesasDTO>> GetAllAsync();
    public Task<DespesasDTO> Insert(DespesasDTO desp);
    public Task<DespesasDTO> GetDespesa(int id);
    public Task<PagedListResponse<DespesasDTO>> GetDespesaPaginate(FilterRequest filter);
}