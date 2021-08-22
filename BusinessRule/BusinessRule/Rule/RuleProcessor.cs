using BusinessRule.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule
{
    public class RuleProcessor
    {
        private List<IProcess> Rules { get; set; }

        public RuleProcessor()
        {
            Rules = new List<IProcess>();
        }

        public void AddRule(IProcess process)
        {
            Rules.Add(process);
        }

        public List<string> Run(UserContext context)
        {
            List<string> messages = new List<string>();
            foreach (var item in Rules)
            {
               messages.Add(item.Process(context));
            }
            return messages;
        }

    }
}
