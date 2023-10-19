using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Teste_SKA.Models;

[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private static List<Tarefa> tarefas = new List<Tarefa>();

    [HttpGet]
    public IActionResult GetTarefas()
    {
        return Ok(tarefas);
    }

    [HttpPost]
    public IActionResult AdicionarTarefa([FromBody] Tarefa tarefa)
    {
        tarefa.Id = tarefas.Count + 1;
        tarefas.Add(tarefa);
        return Ok(tarefa);
    }

    [HttpPost("MarcarConcluida/{id}")]
    public IActionResult MarcarTarefaConcluida(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.Concluida = true;
        return Ok(tarefa);
    }

    [HttpDelete("RemoverTarefa/{id}")]
    public IActionResult RemoverTarefa(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        tarefas.Remove(tarefa);
        return Ok(tarefa);
    }
}