using HabitAqui.Models;

namespace HabitAqui.ViewModels
{
    public class RecebeHabitacaoViewModel
    {
        public List<Equipamento>? Equipamentos { get; set; }
        public int FuncionarioRecebeuId { get; set; }
        public string? Danos { get; set; }
        public List<byte[]>? Fotos { get; set; }
        public String? Observacoes { get; set; }
    }
}
