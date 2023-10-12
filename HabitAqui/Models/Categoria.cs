namespace HabitAqui.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }

        // uma categoria tem varias habitacoes
        public ICollection<Habitacao> Habitacao { get; set;}
    }
}
