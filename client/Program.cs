using Grpc.Core;

namespace client
{
    public class Program
    {
        internal static Channel channel;

        static async Task Main(string[] args)
        {
            await Init();
            Console.WriteLine("Hello, World!");
        }

        static async Task Init()
        {
            channel = new Channel("localhost:7777", ChannelCredentials.Insecure);

            try
            {
                await channel.ConnectAsync();
                Console.WriteLine("The client connected successfuly to the server");

                //var client = new HelloService.HelloServiceClient(channel);
                //var request = new HelloRequest
                //{
                //    FirstName = "Fabio",
                //    LastName = "Carvalho",
                //};

                //request.Children.AddRange(new[]
                //{
                //    new Child { FirstName = "Batman"},
                //    new Child { FirstName = "Clark"}
                //});

                //var response = await client.WelcomeAsync(request);
                //Console.WriteLine(response.Message);

                var client = new MathsService.MathsServiceClient(channel);
                var response = client.Factorial(new FactoriaRequest { Value = 10 });
                while (await response.ResponseStream.MoveNext())
                {
                    Console.WriteLine($"Factorial of {response.ResponseStream.Current.Value} is equals to {response.ResponseStream.Current.Result}");
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}", ex);
            }
            finally
            {
                if (channel != null)
                {
                    await channel.ShutdownAsync();
                }
            }
        }
    }
}