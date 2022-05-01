using System;
using System.Collections.Generic;

#nullable disable

namespace Session.Data.Models
{
    public partial class VwOrderWrapper
    {
        public string COrderNo { get; set; }
        public string CToyId { get; set; }
        public short SiQty { get; set; }
        public string VDescription { get; set; }
        public decimal MWrapperRate { get; set; }
    }
}
