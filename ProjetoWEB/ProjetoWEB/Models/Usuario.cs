namespace ProjetoWEB.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<Tarefas> Tarefas { get; set; }
    }
}
