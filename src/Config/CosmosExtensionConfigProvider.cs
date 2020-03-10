// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Cosmos;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Options;
using Mobsites.Cosmos.Stream.API.Services;
using System;

namespace Mobsites.Cosmos.Stream.API.Config
{
    /// <summary>
    /// Defines the configuration options for the Http binding.
    /// </summary>
    [Extension("HTTP")]
    internal class CosmosExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly CosmosOptions options;

        public CosmosExtensionConfigProvider(IOptions<CosmosOptions> options)
        {
            this.options = options.Value;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            // Not concerned with binding here as that is taken care of by use of the default Microsoft.Azure.WebJobs.HttpTriggerAttribute.

            if (string.IsNullOrEmpty(options.ConnectionString))
            {
                string error =
                    $"The Cosmos connection string must be set via an IConfiguration connection string named '{Constants.DefaultConnectionStringName}' or a setting of the same name.";
                throw new InvalidOperationException(error);
            }

            CosmosService.Client ??= new CosmosClient(options.ConnectionString, BuildClientOptions(options));
        }

        private CosmosClientOptions BuildClientOptions(CosmosOptions options)
        {
            CosmosClientOptions clientOptions = new CosmosClientOptions();
            if (options.ConnectionMode.HasValue)
            {
                // Default is Direct
                clientOptions.ConnectionMode = options.ConnectionMode.Value;
            }

            if (!string.IsNullOrEmpty(options.ApplicationName))
            {
                clientOptions.ApplicationName = options.ApplicationName;
            }

            if (!string.IsNullOrEmpty(options.ApplicationRegion))
            {
                clientOptions.ApplicationRegion = options.ApplicationRegion;
            }

            return clientOptions;
        }
    }
}