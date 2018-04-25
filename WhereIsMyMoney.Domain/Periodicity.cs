﻿namespace WhereIsMyMoney.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Periodicity
    {
        [Key]
        public int PeriodicityId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Periodicity_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Periodicity_Name_Index", IsUnique = true)]
        [Display(Name = "Periodicidad")]
        public string Name { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<AuthorPlan> AuthorPlans { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }

        [JsonIgnore]
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
    }
}
