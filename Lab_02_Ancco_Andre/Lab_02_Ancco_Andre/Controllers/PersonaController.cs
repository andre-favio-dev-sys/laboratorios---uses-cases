using Lab_02_Ancco_Andre.Models;
using Lab_02_Ancco_Andre.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab_02_Ancco_Andre.Controllers;

[ApiController]
[Route("api/personas")]
public class PersonaController : ControllerBase
{
    private static List<Persona> personas = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(personas);

    [HttpGet("{dni}")]
    public IActionResult GetByDni(int dni)
    {
        var persona = personas.FirstOrDefault(p => p.Dni == dni);
        if (persona == null) return NotFound(new { message = "Persona no encontrada" });
        return Ok(persona);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PersonaDto dto)
    {
        var persona = new Persona
        {
            Nombre = dto.Nombre,
            Edad = dto.Edad,
            Dni = dto.Dni,
            Email = dto.Email
        };
        personas.Add(persona);
        return Ok(new { message = "Persona creada", persona });
    }

    [HttpPut("{dni}")]
    public IActionResult Update(int dni, [FromBody] PersonaDto dto)
    {
        var persona = personas.FirstOrDefault(p => p.Dni == dni);
        if (persona == null) return NotFound(new { message = "Persona no encontrada" });

        persona.Nombre = dto.Nombre;
        persona.Edad = dto.Edad;
        persona.Dni = dto.Dni;
        persona.Email = dto.Email;

        return Ok(new { message = "Persona actualizada", persona });
    }

    [HttpPatch("{dni}")]
    public IActionResult UpdatePartial(int dni, [FromBody] PersonaDto dto)
    {
        var persona = personas.FirstOrDefault(p => p.Dni == dni);
        if (persona == null) return NotFound(new { message = "Persona no encontrada" });

        if (!string.IsNullOrEmpty(dto.Nombre)) persona.Nombre = dto.Nombre;
        if (dto.Edad != 0) persona.Edad = dto.Edad;
        if (!string.IsNullOrEmpty(dto.Email)) persona.Email = dto.Email;

        return Ok(new { message = "Persona actualizada parcialmente", persona });
    }

    [HttpDelete("{dni}")]
    public IActionResult Delete(int dni)
    {
        var persona = personas.FirstOrDefault(p => p.Dni == dni);
        if (persona == null) return NotFound(new { message = "Persona no encontrada" });

        personas.Remove(persona);
        return Ok(new { message = "Persona eliminada" });
    }
}