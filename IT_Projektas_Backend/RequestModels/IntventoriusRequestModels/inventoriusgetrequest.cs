using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.IntventoriusRequestModels
{
    public class inventoriusgetrequest
    {
        public string Pavadinimas { get; set; }
        public int Kiekis { get; set; }
        public string KabinetoNumeris { get; set; }


        public string Data { get; set; }
        public string LaikasNuo { get; set; }
        public string LaikasIki { get; set; }


    }
}
