using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    internal class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Departament> Departaments { get; set; } = new List<Departament>();
    }
}
