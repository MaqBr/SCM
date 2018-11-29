using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.ApplicationCore.Entity
{
    public class Proprietario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Veiculo> Veiculos { get; set; }
        public Endereco Endereco { get; set; }
    }
}
