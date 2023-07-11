using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JPV
{
    public class Candidato
    {
        public int CdCandidato { get; set; }
        public string NmCandidato { get; set; }
        public DateTime DtNascCandidato { get; set; }
        public decimal VlRendaCandidato { get; set; }
        public string CdCpf { get; set; }

    }
}