using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public partial class Orcamento
    {
        public long Id { get; set; }

        [Display(Name = "Cliente")]
        public string ClienteCpf { get; set; } = null!;
        public string FerramentaCodigo { get; set; } = null!;
        public decimal ValorTotal { get; set; }


        [Display(Name = "Data inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataOrcamento { get; set; }


        [Display(Name = "Data final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataValidade { get; set; }

        public virtual Cliente? ClienteCpfNavigation { get; set; } = null!;
        public virtual Ferramentum? FerramentaCodigoNavigation { get; set; } = null!;

        
    }

 
}
