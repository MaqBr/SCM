﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.ApplicationCore.Entity
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        //Propriedade de Navegação (Navigation Property)
        public List<Multa> Multas { get; set; }
        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }

        public int ProprietarioId { get; set; }
        public Proprietario Proprietario { get; set; }
        public List<AcessorioVeiculo> AcessoriosVeiculos { get; set; }
    }
}
