using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public class Viaticos_DetalleMetadata
    {
        public int Id { get; set; }

        public int IdCabecera { get; set; }

        public int IdConcepto { get; set; }

        [Range(1, 9999, ErrorMessage = "El valor para {0} debe estar entre {1} and {2}.")]
        public int Cantidad { get; set; }

        [Display(Name = "Precio Unitario")]
        public decimal PrecioUnitario { get; set; }

        [Display(Name = "Total Gasto")]
        public decimal TotalGasto { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        public int IdUsuarioIngreso { get; set; }

        public int Estado { get; set; }
    }

    [MetadataType(typeof(Viaticos_DetalleMetadata))]
    public partial class Viaticos_Detalle
    {

    }
}