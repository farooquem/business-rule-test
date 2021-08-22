using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.Services
{
    public class GenerateSlip : IProcess
    {
        public string Process(Context context)
        {
            return "Slip generated";
        }
    }
}
