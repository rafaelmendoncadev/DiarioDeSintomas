using System;

namespace DiarioDeSintomas.Models
{
    public class DiarioSintoma
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Atividade { get; set; }
        public string Sintoma { get; set; }
        public string Duracao { get; set; }
        public string PressaoArterial { get; set; }
        public string OutrosSintomas { get; set; }
        public string Medicamentos { get; set; }
        public string AlimentacaoHidratacao { get; set; }
        public string Observacoes { get; set; }
    }
}
