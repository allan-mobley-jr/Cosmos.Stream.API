// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using System.Net.Http;

namespace Mobsites.Cosmos.Stream.API.Services
{
    public static partial class CosmosService
    {
        internal static HttpResponseMessage ErrorResponse(string message) => new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadRequest,
            Content = new StringContent(message)
        };
    }
}