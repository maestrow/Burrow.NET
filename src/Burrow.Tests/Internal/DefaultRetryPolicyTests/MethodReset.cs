﻿using System.Threading;
using Burrow.Internal;using NUnit.Framework;


// ReSharper disable InconsistentNaming
namespace Burrow.Tests.Internal.DefaultRetryPolicyTests
{
    [TestFixture]
    public class MethodReset
    {
        [Test]
        public void Should_reset_delay_time_to_0()
        {
            // Arrange
            var are = new AutoResetEvent(false);
            var policy = new DefaultRetryPolicy();
            policy.WaitForNextRetry(() => are.Set());
            Assert.IsTrue(are.WaitOne(1000));

            // Action
            policy.Reset();

            // Assert
            Assert.AreEqual(0, policy.DelayTime);
            Assert.IsFalse(policy.IsWaiting);
        }
    }
}
// ReSharper restore InconsistentNaming