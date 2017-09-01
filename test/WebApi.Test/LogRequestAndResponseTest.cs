﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xlent.Lever.Libraries2.Core.Application;
using Xlent.Lever.Libraries2.Core.Logging.Model;
using Xlent.Lever.Libraries2.WebApi.Pipe.Inbound;

namespace Xlent.Lever.Libraries2.WebApi.Test
{
    [TestClass]
    public class LogRequestAndResponseTest
    {


        [TestMethod]
        public void TestMethod1()
        {
            var logger = new Mock<IFulcrumLogger>();
            ApplicationSetup.Logger = logger.Object;
            logger.Setup(x => x.LogAsync(It.IsAny<LogSeverityLevel>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask)
                .Callback<LogSeverityLevel, string>(
                    (level, message) =>
                    {
                        
                    }
                );

            var logRequestAndResponse = new LogRequestAndResponse();
            // TODO: How to test?
        }
    }
}
