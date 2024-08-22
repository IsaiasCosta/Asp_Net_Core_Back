namespace Asp_Net_Core_Back.Models
{

    public class Atividade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Prioridade Prioridade { get; set; }

        public Atividade() { }
        public Atividade(int id)
        {
            Id = id;
        }
    }
}