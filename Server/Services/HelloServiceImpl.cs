using Grpc.Core;
using static HelloService;

namespace Server.Services
{
    public class HelloServiceImpl : HelloServiceBase
    {
        public HelloServiceImpl() { }

        public override Task<HelloResponse> Welcome(HelloRequest request, ServerCallContext context)
        {
            return base.Welcome(request, context);
        }
    }
}
