//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exemplo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fornecedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fornecedores()
        {
            this.Despesa = new HashSet<Despesa>();
        }
    
        public int Id_Fornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string NIPC { get; set; }
        public string Morada { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Despesa> Despesa { get; set; }
    }
}
