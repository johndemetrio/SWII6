using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP02.Models
{
    public class BillOfLading
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Consignee { get; set; }
        public string Navio { get; set; }

        public virtual ICollection<Container>? Containers { get; set; }
    }
}