using System.ComponentModel.DataAnnotations;

namespace ProjetoWEB.Models
{
    public class Tarefas
    {
        public int ID { get; set; }
        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
        public string DetalhesTarefa { get; set; }
        public DateTime DataTarefa { get; set; }

       
        public PrioridadeTarefa Prioridadade { get; set; }
    }
}
