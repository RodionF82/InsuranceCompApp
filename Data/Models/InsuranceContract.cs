//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceCompApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InsuranceContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InsuranceContract()
        {
            this.ContractClient = new HashSet<ContractClient>();
        }
    
        public int IdContract { get; set; }
        public System.DateTime DateCons { get; set; }
        public System.DateTime DateEnd { get; set; }
        public int IdStatus { get; set; }
        public int IdInsureType { get; set; }
        public int IdEmployee { get; set; }
        public int IdVehicle { get; set; }
        public int IdRegion { get; set; }
        public Nullable<double> Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractClient> ContractClient { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }
        public virtual Region Region { get; set; }
        public virtual StatusContract StatusContract { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}