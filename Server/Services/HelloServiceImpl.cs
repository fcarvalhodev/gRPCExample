using Grpc.Core;
using static HelloService;

namespace Server.Services
{
    public class HelloServiceImpl : HelloServiceBase
    {
        public HelloServiceImpl() { }

        public override Task<HelloResponse> Welcome(HelloRequest request, ServerCallContext context)
        {
            string message = $"Hello there {request.FirstName} {request.LastName} and  " +
                $"{string.Join(',', request.Children.Select(c => c.FirstName))}";
            return Task.FromResult(new HelloResponse { Message = message });
        }
    }
}
