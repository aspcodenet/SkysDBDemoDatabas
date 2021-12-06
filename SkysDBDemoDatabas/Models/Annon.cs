using System;
using System.Collections.Generic;

#nullable disable

namespace SkysDBDemoDatabas.Models
{
    public partial class Annon
    {
        public Annon()
        {
            Bilds = new HashSet<Bild>();
            Buds = new HashSet<Bud>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Titel { get; set; }
        public string Beskrivning { get; set; }
        public int Startpris { get; set; }
        public DateTime Startdatumutc { get; set; }
        public DateTime? Slutdatumutc { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Bild> Bilds { get; set; }
        public virtual ICollection<Bud> Buds { get; set; }
    }
}
