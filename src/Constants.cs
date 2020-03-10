// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Mobsites.Cosmos.Stream.API
{
    public static class Constants
    {
        public const string DefaultConnectionStringName = "Cosmos";
        public const string CosmosAPIRouteForm = "cosmos/{database}/{container}/{partitionKey}";
        public const string CosmosAPIRoutePrefix = "cosmos";
    }
}