using BusinessRule.Services;
using System;
using System.Collections.Generic;

namespace BusinessRule
{
    public class PaymentRuleManager
    {
        private readonly RuleProcessor RuleProcessor;

        public PaymentRuleManager(RuleProcessor ruleProcessor)
        {
            RuleProcessor = ruleProcessor;
        }
        private void BuildRule(PaymentType paymentType, UserContext userContext)
        {
            switch (paymentType)
            {
                case PaymentType.PhysicalProduct:
                    RuleProcessor.AddRule(new GenerateSlip());
                    RuleProcessor.AddRule(new AgentCommission());
                    break;
                case PaymentType.Book:
                    RuleProcessor.AddRule(new GenerateSlip());
                    RuleProcessor.AddRule(new DuplicatePackagingSlip());
                    RuleProcessor.AddRule(new AgentCommission());
                    break;
                case PaymentType.Membership:
                    RuleProcessor.AddRule(new ActivateMembership());
                    RuleProcessor.AddRule(new ConfirmMembership(false));
                    break;
                case PaymentType.UpgradeMembership:
                    RuleProcessor.AddRule(new UpgradeMembership());
                    RuleProcessor.AddRule(new ConfirmMembership(true));
                    break;
                case PaymentType.VideoLearningToSki:
                    RuleProcessor.AddRule(new FreePackaging());
                    break;
            }
        }

        public List<string> Execute(PaymentType payment, UserContext userContext)
        {
            BuildRule(payment, userContext);
            return RuleProcessor.Run(userContext);
        }
    }
}
