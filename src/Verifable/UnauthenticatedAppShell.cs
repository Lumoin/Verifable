using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verifable
{
    public partial class UnauthenticatedAppShell: Shell
    {
        public UnauthenticatedAppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute("ForgotPasswordPage", typeof(Views.Account.ForgotPasswordPage));
        }
    }
}
