using System;
using System.Collections.Generic;

#nullable disable

namespace SkysDBDemoDatabas.Models
{
    public partial class Bud
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnnonsId { get; set; }
        public int Belopp { get; set; }
        public DateTime Datumutc { get; set; }

        public virtual Annon Annons { get; set; }
        public virtual User User { get; set; }
    }
}
