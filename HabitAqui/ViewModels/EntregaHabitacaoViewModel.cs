
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HabitAqui.Models;

namespace HabitAqui.ViewModels
{
    public class EntregaHabitacaoViewModel
    {
        public int HabitacaoId { get; set; }

        public List<Equipamento> EquipamentosOpcionais { get; set; }

        public List<Dano> Danos { get; set; }

        public string Observacoes { get; set; }

        public string FuncionarioEntregaId { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public decimal Custo { get; set; }

        public Funcionario FuncionarioEntrega { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}

