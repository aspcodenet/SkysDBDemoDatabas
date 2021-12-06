using System;
using System.Collections.Generic;

#nullable disable

namespace SkysDBDemoDatabas.Models
{
    public partial class Bild
    {
        public int Id { get; set; }
        public int AnnonsId { get; set; }
        public string Url { get; set; }
        public string Beskrivning { get; set; }
        public bool Isstartbild { get; set; }

        public virtual Annon Annons { get; set; }
    }
}
