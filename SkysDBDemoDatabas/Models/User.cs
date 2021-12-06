using System;
using System.Collections.Generic;

#nullable disable

namespace SkysDBDemoDatabas.Models
{
    public partial class User
    {
        public User()
        {
            Annons = new HashSet<Annon>();
            Buds = new HashSet<Bud>();
            Inloggnings = new HashSet<Inloggning>();
        }

        public int Id { get; set; }
        public string Anvnamn { get; set; }
        public string Password { get; set; }
        public string Namn { get; set; }
        public string Adress { get; set; }
        public int? Postnummer { get; set; }
        public string Stad { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Annon> Annons { get; set; }
        public virtual ICollection<Bud> Buds { get; set; }
        public virtual ICollection<Inloggning> Inloggnings { get; set; }
    }
}
