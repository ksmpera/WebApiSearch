using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public interface IHashable
    {
       string HashCode { get; set; }
    }

    [Serializable]
    public class Test : IHashable
    {
        public string Letter { get; set; }

        public string HashCode { get; set; }        
    }
}
