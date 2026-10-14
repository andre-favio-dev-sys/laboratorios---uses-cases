using Lab_02_Ancco_Andre.Models;
using Lab_02_Ancco_Andre.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab_02_Ancco_Andre.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoController : ControllerBase
{
    private static List<Auto> autos = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(autos);

    [HttpGet("{placa}")]
    public IActionResult GetByPlaca(string placa)
    {
        var auto = autos.FirstOrDefault(a => a.Placa == placa);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });
        return Ok(auto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AutoDto dto)
    {
        var auto = new Auto
        {
            Placa = dto.Placa,
            Sede = dto.Sede,
            TipoPropietario = dto.TipoPropietario,
            PropietarioDni = dto.PropietarioDni,
            PropietarioEmpresaId = dto.PropietarioEmpresaId
        };
        autos.Add(auto);
        return Ok(new { message = "Auto creado", auto });
    }

    [HttpPut("{placa}")]
    public IActionResult Update(string placa, [FromBody] AutoDto dto)
    {
        var auto = autos.FirstOrDefault(a => a.Placa == placa);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        auto.Placa = dto.Placa;
        auto.Sede = dto.Sede;
        auto.TipoPropietario = dto.TipoPropietario;
        auto.PropietarioDni = dto.PropietarioDni;
        auto.PropietarioEmpresaId = dto.PropietarioEmpresaId;

        return Ok(new { message = "Auto actualizado", auto });
    }

    [HttpPatch("{placa}")]
    public IActionResult UpdatePartial(string placa, [FromBody] AutoDto dto)
    {
        var auto = autos.FirstOrDefault(a => a.Placa == placa);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        if (!string.IsNullOrEmpty(dto.Sede)) auto.Sede = dto.Sede;
        if (!string.IsNullOrEmpty(dto.TipoPropietario)) auto.TipoPropietario = dto.TipoPropietario;

        return Ok(new { message = "Auto actualizado parcialmente", auto });
    }

    [HttpDelete("{placa}")]
    public IActionResult Delete(string placa)
    {
        var auto = autos.FirstOrDefault(a => a.Placa == placa);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        autos.Remove(auto);
        return Ok(new { message = "Auto eliminado" });
    }
}