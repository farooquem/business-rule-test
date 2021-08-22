using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.Services
{
    public class GenerateSlip : IProcess
    {
        public string Process(UserContext context)
        {
            return "Slip generated";
        }
    }
}
