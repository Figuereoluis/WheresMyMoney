namespace WhereIsMyMoney.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Origin
    {
        [Key]
        public int OriginId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(2, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(10, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(25, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public string Simbol { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Account> Accounts { get; set; }

        [JsonIgnore]
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<Operation> Operations { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountType> AccountTypes { get; set; }
        
    }
}
