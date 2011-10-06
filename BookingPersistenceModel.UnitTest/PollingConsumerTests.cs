﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Extensions;
using Ploeh.AutoFixture.Xunit;
using Ploeh.Samples.Booking.PersistenceModel;
using Xunit;
using System.IO;
using Moq;

namespace Ploeh.Samples.Booking.PersistenceModel.UnitTest
{
    public class PollingConsumerTests
    {
        [Theory, AutoPersistenceData]
        public void ConsumeAllDispatchesAllStreams(
            [Frozen]Mock<IQueue> queueStub,
            [Frozen]Mock<IObserver<Stream>> consumerMock,
            PollingConsumer sut,
            IEnumerable<Stream> streams)
        {
            queueStub
                .Setup(q => q.GetEnumerator())
                .Returns(streams.GetEnumerator());

            sut.ConsumeAll();

            streams.ToList().ForEach(s =>
                consumerMock.Verify(c =>
                    c.OnNext(s)));
        }

        [Theory, AutoPersistenceData]
        public void ConsumeAllDeletesStreams(
            [Frozen]Mock<IQueue> queueMock,
            PollingConsumer sut,
            IEnumerable<Stream> streams)
        {
            queueMock
                .Setup(q => q.GetEnumerator())
                .Returns(streams.GetEnumerator());

            sut.ConsumeAll();

            streams.ToList().ForEach(s =>
                queueMock.Verify(q =>
                    q.Delete(s)));
        }
    }
}
