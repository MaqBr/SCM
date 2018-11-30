using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.ApplicationCore.Entity
{
    public class AcessorioVeiculo
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int AcessorioId { get; set; }
        public Acessorio Acessorio { get; set; }
    }
}
