using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.ApplicationCore.Entity
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
