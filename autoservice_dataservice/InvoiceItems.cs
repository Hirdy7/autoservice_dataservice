//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace autoservice_dataservice
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceItems
    {
        public int InvoiceItemID { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
    
        public virtual Invoices Invoices { get; set; }
        public virtual Services Services { get; set; }
    }
}
