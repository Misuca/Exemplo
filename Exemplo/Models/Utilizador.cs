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
    
    public partial class Utilizador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilizador()
        {
            this.Utilizaçao_Permanente = new HashSet<Utilizaçao_Permanente>();
            this.Utilizaçao_Temporaria = new HashSet<Utilizaçao_Temporaria>();
        }
    
        public int Id_Utilizador { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public Nullable<int> CC { get; set; }
        public string Morada { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidade { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilizaçao_Permanente> Utilizaçao_Permanente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilizaçao_Temporaria> Utilizaçao_Temporaria { get; set; }
    }
}
