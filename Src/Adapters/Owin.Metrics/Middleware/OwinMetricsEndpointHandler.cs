﻿using System.Collections.Generic;
using System.Linq;
using Metrics.Visualization;

namespace Owin.Metrics.Middleware
{
    public class OwinMetricsEndpointHandler : AbstractMetricsEndpointHandler<IDictionary<string, object>>
    {
        public OwinMetricsEndpointHandler(IEnumerable<MetricsEndpoint> endpoints) : base(endpoints) { }

        protected override MetricsEndpointRequest CreateRequest(IDictionary<string, object> requestInfo)
        {
            var owinRequestHeaders = requestInfo["owin.RequestHeaders"] as IDictionary<string, string[]>;
            var headers = owinRequestHeaders.ToDictionary(p => p.Key, p => p.Value.Single());

            return new MetricsEndpointRequest(headers);
        }
    }
}