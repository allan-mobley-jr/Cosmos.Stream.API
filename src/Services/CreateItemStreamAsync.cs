// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Cosmos;
using Mobsites.Cosmos.Stream.API.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mobsites.Cosmos.Stream.API.Services
{
    public static partial class CosmosService
    {
        internal static async Task<HttpResponseMessage> CreateItemStreamAsync(
            string database,
            string container,
            string partitionKey,
            System.IO.Stream stream) => (await GetContainer(database, container)
                .CreateItemStreamAsync(stream, new PartitionKey(partitionKey)))
                .ConvertHttpResponseMessage();
    }
}