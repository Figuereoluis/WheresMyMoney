namespace WhereIsMyMoney.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Budget
    {
        public int BudgetId { get; set; }

        [Display(Name = "Monto Estimado")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //public decimal PreviousAmount { get; set; }

        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public int StatusId { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }

    }
}
