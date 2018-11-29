using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.ApplicationCore.Entity
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int ProprietarioId { get; set; }
        public Proprietario Proprietario { get; set; }
    }
}
