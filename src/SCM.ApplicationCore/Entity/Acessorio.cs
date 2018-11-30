using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.ApplicationCore.Entity
{
    public class Acessorio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<AcessorioVeiculo> AcessoriosVeiculos { get; set; }
    }
}
