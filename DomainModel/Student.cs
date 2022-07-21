using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Student : Person
    {
        public bool IsClassDelegate { get; set; }

        public double Average { get; set; }
    }
}
