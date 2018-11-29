using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.ApplicationCore.Entity
{
    public class Multa
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public double Pontuacao { get; set; }
        //Propriedade de Navegação (Navigation Property)
        public Veiculo Veiculo { get; set; }
    }
}
