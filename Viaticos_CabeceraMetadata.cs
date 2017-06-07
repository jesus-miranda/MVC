using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public class Viaticos_CabeceraMetadata
    {
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Valor Solicitado")]
        //[RegularExpression(@"^\$?\d+(\,(\d{2}))?$", ErrorMessage = "El valor para {0} debe tener el siguiente formato 12345,67")]
        public decimal ValorSolicitado { get; set; }

        [DefaultValue(0)]
        [Range(0, Double.PositiveInfinity)]
        [Display(Name = "Valor Aprobado")]
        //[RegularExpression(@"^\$?\d+(\,(\d{2}))?$", ErrorMessage = "El valor para {0} debe tener el siguiente formato 12345,67")]
        public decimal ValorAprobado { get; set; }

        [Display(Name = "Número Semana")]
        [Range(1, 52, ErrorMessage = "El valor para {0} debe estar entre {1} and {2}.")]
        public int NumeroSemana { get; set; }

        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Fecha Registro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }

        [StringLength(50, ErrorMessage= "Se aceptan máximo {1} caracteres")]
        public string DestinoViaje { get; set; }

        [DefaultValue("VIA-")]
        [StringLength(10)]
        public string Secuencial { get; set; }

        public int Estado { get; set; }
    }

    [MetadataType(typeof(Viaticos_CabeceraMetadata))]
    public partial class Viaticos_Cabecera
    {

    }
}