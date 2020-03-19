using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Config
    {
        public uint Version { get; set; }
        public ContractDetails Contract { get; set; }
    }

    public class ContractDetails
    {
        public string Author { get; set; }
        public bool HasStorage { get; set; }
        public IEnumerable<string> Parameters { get; set; }

    }
}
