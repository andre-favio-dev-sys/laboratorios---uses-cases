using Lab_02_Ancco_Andre.Models;
using Lab_02_Ancco_Andre.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab_02_Ancco_Andre.Controllers;

[ApiController]
[Route("api/empresas")]
public class EmpresaController : ControllerBase
{
    private static List<Empresa> empresas = new();
    private static int nextId = 1;

    [HttpGet]
    public IActionResult GetAll() => Ok(empresas);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var empresa = empresas.FirstOrDefault(e => e.Id == id);
        if (empresa == null) return NotFound(new { message = "Empresa no encontrada" });
        return Ok(empresa);
    }

    [HttpPost]
    public IActionResult Create([FromBody] EmpresaDto dto)
    {
        var empresa = new Empresa
        {
            Id = nextId++,
            RazonSocial = dto.RazonSocial,
            Ruc = dto.Ruc
        };
        empresas.Add(empresa);
        return Ok(new { message = "Empresa creada", empresa });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] EmpresaDto dto)
    {
        var empresa = empresas.FirstOrDefault(e => e.Id == id);
        if (empresa == null) return NotFound(new { message = "Empresa no encontrada" });

        empresa.RazonSocial = dto.RazonSocial;
        empresa.Ruc = dto.Ruc;

        return Ok(new { message = "Empresa actualizada", empresa });
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePartial(int id, [FromBody] EmpresaDto dto)
    {
        var empresa = empresas.FirstOrDefault(e => e.Id == id);
        if (empresa == null) return NotFound(new { message = "Empresa no encontrada" });

        if (!string.IsNullOrEmpty(dto.RazonSocial)) empresa.RazonSocial = dto.RazonSocial;
        if (!string.IsNullOrEmpty(dto.Ruc)) empresa.Ruc = dto.Ruc;

        return Ok(new { message = "Empresa actualizada parcialmente", empresa });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var empresa = empresas.FirstOrDefault(e => e.Id == id);
        if (empresa == null) return NotFound(new { message = "Empresa no encontrada" });

        empresas.Remove(empresa);
        return Ok(new { message = "Empresa eliminada" });
    }
}