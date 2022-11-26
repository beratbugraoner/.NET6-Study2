using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SepetUrun
    {
        public int Id { get; set; }
        public int SepetId { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
