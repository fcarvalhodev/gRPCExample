using Grpc.Core;
using Server.Services;

namespace Server
{
    public class Program
    {
        internal static Grpc.Core.Server gRPCServer;

        static void Main(string[] args)
        {
            Init();
            Console.WriteLine("Hello, World!");
        }

        static async void Init()
        {
            gRPCServer = new Grpc.Core.Server()
            {
                Ports = { new ServerPort("localhost", 7777, ServerCredentials.Insecure) },
                Services = { HelloService.BindService(new HelloServiceImpl()),
                MathsService.BindService(new MathsServicesImpl()) }
            };

            try
            {
                gRPCServer.Start();
                Console.WriteLine("Server is listening to port 7777");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (gRPCServer != null)
                {
                    await gRPCServer.ShutdownAsync();
                }
            }
        }
    }
}