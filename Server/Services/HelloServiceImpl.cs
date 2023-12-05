using Grpc.Core;
using static HelloService;

namespace Server.Services
{
    public class HelloServiceImpl : HelloServiceBase
    {
        public HelloServiceImpl() { }

        public override Task<HelloResponse> Welcome(HelloRequest request, ServerCallContext context)
        {
            string message = $"{request.FirstName} {request.LastName}";
            return Task.FromResult(new HelloResponse { Message = message });
        }
    }
}
