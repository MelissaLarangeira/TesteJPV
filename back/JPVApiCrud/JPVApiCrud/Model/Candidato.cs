using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Net.Security;
using Microsoft.AspNetCore.Mvc.Razor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JPVApiCrud.Model
{
    [Table("TBL_CANDIDATO")]
    public class Candidato
    {
        public int? CdCandidato { get; set; }

        [Required]
        [MaxLength(100)]
        public string NmCandidato { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DtNascCandidato { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal VlRendaCandidato { get; set; }

        [Required]
        [RegularExpression(@"\d{11}$")]
        public string CdCpf { get; set; }

    }
}
