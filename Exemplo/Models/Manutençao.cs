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
    
    public partial class Manutençao
    {
        public int Id_Viatura { get; set; }
        public Nullable<System.DateTime> DataManutençao { get; set; }
        public string Reparaçao { get; set; }
        public string Fatura { get; set; }
        public Nullable<int> Preço { get; set; }
        public int Id_Manutencao { get; set; }
    
        public virtual Viatura Viatura { get; set; }
    }
}
