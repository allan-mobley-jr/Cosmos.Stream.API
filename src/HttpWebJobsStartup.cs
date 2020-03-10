// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Mobsites.Cosmos.Stream.API;
using Mobsites.Cosmos.Stream.API.Extensions;

[assembly: WebJobsStartup(typeof(HttpWebJobsStartup))]

namespace Mobsites.Cosmos.Stream.API
{
    /// <summary>
    /// Enable dynamic HTTP registration against WebJobs. 
    /// </summary>
    public class HttpWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddCosmos();
        }
    }
}