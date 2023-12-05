using Grpc.Core;
using static MathsService;

namespace Server.Services
{
    public class MathsServicesImpl : MathsServiceBase
    {
        public override async Task Factorial(FactoriaRequest request,
            IServerStreamWriter<FactoriaResponse> responseStream,
            ServerCallContext context)
        {
            long total = 1;
            for (int i = 1; i <= request.Value; i++)
            {
                total += i;
                await responseStream.WriteAsync(new FactoriaResponse
                {
                    Value = i,
                    Result = total,
                });
            }

            await Task.Delay(1000);
        }
    }
}
