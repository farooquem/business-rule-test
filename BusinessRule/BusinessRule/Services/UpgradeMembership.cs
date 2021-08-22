using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.Services
{
    public class UpgradeMembership : IProcess
    {
        public string Process(Context context)
        {
            return "Membership upgraded";
        }
    }
}
