using System;
using System.Collections.Generic;

namespace DesafioAPI
{
    public partial class Cooperado
    {
        public Cooperado()
        {
            InverseICodCooperativaNavigation = new HashSet<Cooperado>();
        }

        public int ICodCooperado { get; set; }
        public int ICodCooperativa { get; set; }
        public int IContaCorrente { get; set; }
        public string SNomeCooperado { get; set; }

        public Cooperado ICodCooperativaNavigation { get; set; }
        public ICollection<Cooperado> InverseICodCooperativaNavigation { get; set; }
    }
}
