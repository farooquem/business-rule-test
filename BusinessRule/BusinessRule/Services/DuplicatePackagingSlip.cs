using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.Services
{
    public class DuplicatePackagingSlip : IProcess
    {
        public string Process(UserContext context)
        {
            return "Duplicate packaging slip";
        }
    }
}
