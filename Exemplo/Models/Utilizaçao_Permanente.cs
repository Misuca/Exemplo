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
    
    public partial class Utilizaçao_Permanente
    {
        public int Id_Utilizador { get; set; }
        public int Id_Viatura { get; set; }
        public string Matricula { get; set; }
        public Nullable<System.DateTime> DataInicio { get; set; }
        public Nullable<System.DateTime> DataFim { get; set; }
    
        public virtual Utilizador Utilizador { get; set; }
        public virtual Viatura Viatura { get; set; }
    }
}
