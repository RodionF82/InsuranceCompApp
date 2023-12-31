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
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.ContractClient = new HashSet<ContractClient>();
        }
    
        public int IdClient { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Passport { get; set; }
        public System.DateTime Birthday { get; set; }
        public string E_mail { get; set; }
        public System.DateTime DriversLicenseDate { get; set; }
        public string Phone { get; set; }
        public int NumOfCrashYear { get; set; }
        public Nullable<int> IdClassKBM { get; set; }
    
        public virtual ClassKBM ClassKBM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractClient> ContractClient { get; set; }
    }
}
