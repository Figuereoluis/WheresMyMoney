namespace WhereIsMyMoney.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Operation
    {
        public int OperationId { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Tipo")]
        public int OriginId { get; set; }

        [Display(Name = "Cuenta")]
        public int AccountId { get; set; }

        [Display(Name = "Cuenta Destino")]
        public int? AccountId2 { get; set; }

        [Display(Name = "Etiqueta (Concepto)")]
        public int TagId { get; set; }

        [Display(Name = "Monto")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //public decimal PreviousAmount { get; set; }

        [Display(Name = "Recurrente?")]
        public bool Recurrent { get; set; }

        [Display(Name = "Periodicidad")]
        public int PeriodicityId { get; set; }

        [MaxLength(500, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Observaciones")]
        public string Observations { get; set; }

        public int StatusId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Periodicity Periodicity { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Tag Tag { get; set; }
        [JsonIgnore]
        public virtual Origin Origin { get; set; }
    }
}
