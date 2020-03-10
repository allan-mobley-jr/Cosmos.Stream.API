// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Http;

namespace Mobsites.Cosmos.Stream.API.Extensions
{
    public static class PathStringExtensions
    {
        internal static int ParseRoute(
            this PathString route,
            out string database,
            out string container,
            out string partitionKey,
            out string id,
            out int maxItemCount)
        {
            try
            {
                var dirs = ((string)route).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var error = new InvalidOperationException(
                    $"'{route}' must at the very least be a valid Cosmos API route containing the form '{Constants.CosmosAPIRouteForm}'.");

                if ((dirs?.Length ?? 0) < 4)
                    throw error;

                // Check for Cosmos API prefix (cannot use dirs.Contains(Constants.CosmosAPIRoutePrefix) here because of casing variants)
                bool hasCosmosAPIPrefix = false;
                int indexOfCosmosAPIPrefix = 0;
                for (int i = 0; i < dirs.Length; i++)
                {
                    if (dirs[i].ToLowerInvariant() == Constants.CosmosAPIRoutePrefix)
                    {
                        hasCosmosAPIPrefix = true;
                        indexOfCosmosAPIPrefix = i;
                        break;
                    }
                }

                if (!hasCosmosAPIPrefix)
                    throw error;

                database = dirs[indexOfCosmosAPIPrefix + 1];
                container = dirs[indexOfCosmosAPIPrefix + 2];
                partitionKey = dirs[indexOfCosmosAPIPrefix + 3];
                id = dirs.Length == indexOfCosmosAPIPrefix + 5 ? dirs[indexOfCosmosAPIPrefix + 4] : null;
                maxItemCount = -1;

                if (dirs.Length == indexOfCosmosAPIPrefix + 6)
                {
                    if (!int.TryParse(dirs[indexOfCosmosAPIPrefix + 5], out maxItemCount))
                    {
                        maxItemCount = -1;
                    }
                }

                return dirs.Length - indexOfCosmosAPIPrefix;
            }
            catch (Exception ex)
            {
                // Rethrow it.
                throw ex;
            }
        }
    }
}