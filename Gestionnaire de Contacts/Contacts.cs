using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_Contacts
{
    internal class Contacts
    {
        public string nom { get; set; }
        public string num { get; set; }

        public Contacts(string nom, string num)
        {
            this.nom = nom;
            this.num = num;
        }
    }
}

