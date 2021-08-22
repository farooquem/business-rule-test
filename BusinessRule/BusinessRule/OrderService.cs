using BusinessRule.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule
{
    public class OrderService
    {
        private readonly PaymentRuleManager PaymentRuleManager;
        public OrderService(PaymentRuleManager paymentRuleManager)
        {
            PaymentRuleManager = paymentRuleManager;
        }

        public List<string> Order(UserContext userContext)
        {
            PaymentType paymentType = PaymentType.None;
            if(userContext.OrderDetail.IsPhysical)
            {
                paymentType = PaymentType.PhysicalProduct;
                if(userContext.OrderDetail.ProductCategory == ProductCategory.Book)
                {
                    paymentType = PaymentType.Book;
                }
            }
            else
            {
                if (userContext.OrderDetail.ProductCategory == ProductCategory.Video
                    && userContext.OrderDetail.ProductName.Equals("Learning to Ski", StringComparison.InvariantCultureIgnoreCase))
                {
                    paymentType = PaymentType.VideoLearningToSki;
                }
                else if(userContext.OrderDetail.ProductCategory == ProductCategory.Membership
                    && userContext.UserDetail.IsUpgraded)
                {
                    paymentType = PaymentType.UpgradeMembership;
                }
                else if (userContext.OrderDetail.ProductCategory == ProductCategory.Membership
                    && userContext.UserDetail.IsActivated)
                {
                    paymentType = PaymentType.Membership;
                }
            }

           return PaymentRuleManager.Execute(paymentType, userContext);
        }
    }
}
