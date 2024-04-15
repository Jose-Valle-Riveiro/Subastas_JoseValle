using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_JoseValle
{
    [Serializable]
    public class Property
    {
        public string property;
        public List<Costumer> customers;
        public int rejection;
    }
}
