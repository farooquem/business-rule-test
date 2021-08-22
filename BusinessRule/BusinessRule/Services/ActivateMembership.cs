using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.Services
{
    public class ActivateMembership : IProcess
    {
        public string Process(Context context)
        {
           return "Membership activated";
        }
    }
}
