//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class productSold
    {
        public int product_id { get; set; }
        public Nullable<int> product_quantity { get; set; }
        public Nullable<int> product_price { get; set; }
        public string product_date { get; set; }
    
        public virtual product product { get; set; }
    }
}
