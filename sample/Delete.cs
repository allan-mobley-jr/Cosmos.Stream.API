using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Mobsites.Cosmos.Stream.API.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mobsites.Cosmos.Stream.API.Sample
{
    public static class Delete
    {
        [FunctionName("Delete")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "cosmos/{database}/{container}/{partitionKey}/{id}")] HttpRequest req) =>
                await req.GetResponseAsync();
    }
}