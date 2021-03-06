﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xlent.Lever.Libraries2.Standard.Error.Logic;
using Xlent.Lever.Libraries2.WebApi.Error.Logic;

namespace Xlent.Lever.Libraries2.WebApi.Pipe.Outbound
{
    /// <summary>
    /// Any non-successful response will be thrown as a <see cref="FulcrumException"/>.
    /// </summary>
    public class ThrowFulcrumExceptionOnFail : DelegatingHandler
    {
        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           var response = await base.SendAsync(request, cancellationToken);
            var fulcrumException = await Converter.ToFulcrumExceptionAsync(response);
            if (fulcrumException != null) throw fulcrumException;
            return response;
        }
    }
}
