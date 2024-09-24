using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubSystem {
    internal class Member {
        private String? name;
        private int uniqueId;
        private List<Activity> inscriptions;

        public string? Name { get => name; set => name = value; }
        public int UniqueId { get => uniqueId; set => uniqueId = value; }
        internal List<Activity> Inscriptions { get => inscriptions; set => inscriptions = value; }

        public Member(string? name, int uniqueId) {
            this.name = name;
            this.uniqueId = uniqueId;
            this.inscriptions = new List<Activity>();
        }

        public override string ToString() {
            String result = $"Name: {Name}\nID: {UniqueId}\nInscriptions:\n";

            if (inscriptions.Count == 0) {
                result = result + "No activities\n";
            } else {
                foreach (Activity act in Inscriptions) {
                    result = result + act.Name + "\n";
                }
            }
            return result;
        }
    }
}
