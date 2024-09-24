using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubSystem {
    internal class Activity {
        private String? name;
        private int quota;

        public string? Name { get => name; set => name = value; }
        public int Quota { get => quota; set => quota = value; }

        public Activity(string? name, int quota) {
            this.name = name;
            this.quota = quota;
        }

        public override string ToString() {
            return $"Name: {Name}\nQuota: {Quota}\n";
        }
    }
}
