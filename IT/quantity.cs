//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IT
{
    using System;
    using System.Collections.Generic;
    
    public partial class quantity
    {
        public int product_id { get; set; }
        public int quantity1 { get; set; }
    
        public virtual product product { get; set; }
    }
}
