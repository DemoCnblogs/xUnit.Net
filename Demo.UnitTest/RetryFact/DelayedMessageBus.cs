using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Demo.UnitTest.RetryFact
{
    public class DelayedMessageBus : IMessageBus
    {
        private readonly IMessageBus innerBus;
        private readonly List<IMessageSinkMessage> messages = new List<IMessageSinkMessage>();

        public DelayedMessageBus(IMessageBus innerBus)
        {
            this.innerBus = innerBus;
        }

        public bool QueueMessage(IMessageSinkMessage message)
        {
            lock (messages)
                messages.Add(message);

            // No way to ask the inner bus if they want to cancel without sending them the message, so
            // we just go ahead and continue always.
            return true;
        }

        public void Dispose()
        {
            foreach (var message in messages)
                innerBus.QueueMessage(message);
        }
    }
}
