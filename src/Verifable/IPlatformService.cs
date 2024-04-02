using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verifable
{
    public interface IPlatformService
    {
        string Hello();
    }


    public class PlatformService: IPlatformService
    {
        public string Hello()
        {
            return "Hello!";
        }
    }
}
