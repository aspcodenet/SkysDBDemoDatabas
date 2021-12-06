using System;
using System.Collections.Generic;

#nullable disable

namespace SkysDBDemoDatabas.Models
{
    public partial class Inloggning
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Datumutc { get; set; }
        public string Ipadress { get; set; }

        public virtual User User { get; set; }
    }
}
