namespace WhereIsMyMoney.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class AccountType
    {
        [Key]
        public int AccountTypeId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(10, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }

        [Display(Name = "Origen")]
        public int OriginId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Origin Origin { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
