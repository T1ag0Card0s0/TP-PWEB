
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HabitAqui.Models;

namespace HabitAqui.ViewModels
{
    public class EntregaHabitacaoViewModel
    {
        public List<Equipamento>? Equipamentos { get; set; }
        public string? Danos { get; set; }
        public string? Observacoes { get; set; }
    }
}

