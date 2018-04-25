namespace WhereIsMyMoney.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(10, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Cuenta")]
        public string Description { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        [Display(Name = "Tipo")]
        public int? AccountTypeId { get; set; }


        //[Display(Name = "Tipo")]
        //public int? OriginId { get; set; }
        //[Display(Name = "Gastos")]
        //public decimal Amount2 { get; set; }
        //public decimal PreviousAmount { get; set; }

        public int WalletId { get; set; }

        [Display(Name = "Moneda")]
        public int CurrencyId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Currency Currency { get; set; }
        [JsonIgnore]
        public virtual Wallet Wallet { get; set; }
        //[JsonIgnore]
        //public virtual Origin Origin { get; set; }
        [JsonIgnore]
        public virtual AccountType AccountType { get; set; }
        [JsonIgnore]
        public virtual ICollection<Operation> Operations { get; set; }

    }
}
