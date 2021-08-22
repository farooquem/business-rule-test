using BusinessRule.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace BusinessRule.Test
{
    [TestClass]
    public class BusinessRuleTests
    {
        [TestMethod]
        public void PaymentOrderBookTest()
        {
            var userContext = new UserContext
            {
                OrderDetail = new OrderDetail
                {
                    IsPhysical = true,
                    ProductCategory = ProductCategory.Book,
                    ProductName = "Test 1"
                },

                UserDetail = new UserDetail
                {
                    Email = "Test@gmail.com",
                    IsActivated = false,
                    IsUpgraded = false,
                    Username = "Test"
                }
            };

            OrderService orderService = new OrderService(new PaymentRuleManager(new RuleProcessor()));
            var actual = orderService.Order(userContext);
            Assert.AreEqual(actual.Count, 3);
            Assert.IsTrue(actual.Contains("Slip generated"));
            Assert.IsTrue(actual.Contains("Duplicate packaging slip"));
            Assert.IsTrue(actual.Contains("Commission payment to the agent generated"));
        }

        [TestMethod]
        public void PaymentOrderPhysicalTest()
        {
            var userContext = new UserContext
            {
                OrderDetail = new OrderDetail
                {
                    IsPhysical = true,
                    ProductCategory = ProductCategory.Membership,
                    ProductName = "Test 1"
                },

                UserDetail = new UserDetail
                {
                    Email = "Test@gmail.com",
                    IsActivated = false,
                    IsUpgraded = false,
                    Username = "Test"
                }
            };

            OrderService orderService = new OrderService(new PaymentRuleManager(new RuleProcessor()));
            var actual = orderService.Order(userContext);
            Assert.AreEqual(actual.Count, 2);
            Assert.IsTrue(actual.Contains("Slip generated"));
            Assert.IsTrue(actual.Contains("Commission payment to the agent generated"));
        }

        [TestMethod]
        public void PaymentOrderVideoTest()
        {
            var userContext = new UserContext
            {
                OrderDetail = new OrderDetail
                {
                    IsPhysical = false,
                    ProductCategory = ProductCategory.Video,
                    ProductName = "Test 1"
                },

                UserDetail = new UserDetail
                {
                    Email = "Test@gmail.com",
                    IsActivated = false,
                    IsUpgraded = false,
                    Username = "Test"
                }
            };

            OrderService orderService = new OrderService(new PaymentRuleManager(new RuleProcessor()));
            var actual = orderService.Order(userContext);
            Assert.IsTrue(actual.Count == 0);
        }

        [TestMethod]
        public void PaymentOrderVideoTestWithFreeBook()
        {
            var userContext = new UserContext
            {
                OrderDetail = new OrderDetail
                {
                    IsPhysical = false,
                    ProductCategory = ProductCategory.Video,
                    ProductName = "Learning to Ski"
                },

                UserDetail = new UserDetail
                {
                    Email = "Test@gmail.com",
                    IsActivated = false,
                    IsUpgraded = false,
                    Username = "Test"
                }
            };

            OrderService orderService = new OrderService(new PaymentRuleManager(new RuleProcessor()));
            var actual = orderService.Order(userContext);
            Assert.AreEqual(actual.Count, 1);
            Assert.IsTrue(actual.Contains("Add a free “First Aid” video to the packing slip."));
        }

        [TestMethod]
        public void PaymentOrderMembershipActivated()
        {
            var userContext = new UserContext
            {
                OrderDetail = new OrderDetail
                {
                    IsPhysical = false,
                    ProductCategory = ProductCategory.Membership,
                    ProductName = "Learning to Ski"
                },

                UserDetail = new UserDetail
                {
                    Email = "Test@gmail.com",
                    IsActivated = true,
                    IsUpgraded = false,
                    Username = "Test"
                }
            };

            OrderService orderService = new OrderService(new PaymentRuleManager(new RuleProcessor()));
            var actual = orderService.Order(userContext);
            Assert.AreEqual(actual.Count, 2);
            Assert.IsTrue(actual.Contains("Membership activated"));
            Assert.IsTrue(actual.Contains("Activation email has been sent to owner"));
        }

        [TestMethod]
        public void PaymentOrderMembershipUpgraded()
        {
            var userContext = new UserContext
            {
                OrderDetail = new OrderDetail
                {
                    IsPhysical = false,
                    ProductCategory = ProductCategory.Membership,
                    ProductName = "Learning to Ski"
                },

                UserDetail = new UserDetail
                {
                    Email = "Test@gmail.com",
                    IsActivated = false,
                    IsUpgraded = true,
                    Username = "Test"
                }
            };

            OrderService orderService = new OrderService(new PaymentRuleManager(new RuleProcessor()));
           var actual = orderService.Order(userContext);
            Assert.AreEqual(actual.Count, 2);
            Assert.IsTrue(actual.Contains("Membership upgraded"));
            Assert.IsTrue(actual.Contains("Upgrade email has been sent to owner"));
        }

        [TestMethod]
        public void PaymentOrderWithFaultOption()
        {
            var userContext = new UserContext
            {
                OrderDetail = new OrderDetail
                {
                    IsPhysical = false,
                    ProductCategory = ProductCategory.Book,
                    ProductName = "Learning to Ski"
                },

                UserDetail = new UserDetail
                {
                    Email = "Test@gmail.com",
                    IsActivated = false,
                    IsUpgraded = false,
                    Username = "Test"
                }
            };

            OrderService orderService = new OrderService(new PaymentRuleManager(new RuleProcessor()));
            var actual = orderService.Order(userContext);
            Assert.IsTrue(actual.Count == 0);
        }
    }
}
