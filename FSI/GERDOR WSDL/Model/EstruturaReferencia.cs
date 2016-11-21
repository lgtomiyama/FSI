
using System.Collections.Generic;


namespace GERDOR_WSDL
{
    //Criardor: Lucas Garcia Tomiyama
    public class EstruturaReferencia
    {
        public List<EstruturaReferencia> Filhos { get; set; }
        public EstruturaReferencia Pai { get; set; }
        public string Tipo { get; set; }
        public bool requerido { get; set; }
        public string NomeProp { get; set; }
        public string NomeObj { get; set; }
        public string Diretorio { get; set; }
        public string Sigla { get; set; }
        public string Profundidade { get; set; }

        public EstruturaReferencia()
        {
            Filhos = new List<EstruturaReferencia>();
        }
    }
}
