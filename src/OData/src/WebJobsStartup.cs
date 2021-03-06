﻿using Azure.Functions.Extensions.OData;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;

#pragma warning disable CA1812

[assembly: WebJobsStartup(typeof(WebJobsStartup))]
[assembly: InternalsVisibleTo("Azure.Functions.Extensions.OData.Tests")]

namespace Azure.Functions.Extensions.OData
{
    internal class WebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.Services.AddSingleton(serviceProvider =>
                new ODataContext(() => serviceProvider.GetServices<ConfigureODataConventionModelBuilder>()));

            builder.Services.AddSingleton<IBindingProvider, ODataBindingProvider>();
        }
    }
}
