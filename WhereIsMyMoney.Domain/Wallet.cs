namespace WhereIsMyMoney.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(10, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Cartera")]
        public string Description { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //[Display(Name = "Gastos")]
        //public decimal Amount2 { get; set; }
        //public decimal PreviousAmount { get; set; }

        //[Display(Name = "Usuario")]
        //public int UserId { get; set; }

        [Display(Name = "Owner")]
        public int? AuthorId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }

    }
}
