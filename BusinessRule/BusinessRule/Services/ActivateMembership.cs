using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.Services
{
    public class ActivateMembership : IProcess
    {
        public string Process(UserContext context)
        {
           return "Membership activated";
        }
    }
}
