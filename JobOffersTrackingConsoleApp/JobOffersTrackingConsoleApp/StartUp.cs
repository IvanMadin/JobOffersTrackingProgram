using Autofac;
using JobOffersTrackingConsoleApp.AutoConfig;

namespace JobOffersTrackingConsoleApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var container = ConfigurationBuilder.RunBuilder();
            var service = container.Resolve<Service>();
            service.Run();
            


            //Accedia: Junior .NET Developer/WaitingForReply/29.01.2020
            //Soft2Run: WaitingForReply/29.01.2020
            //grafixoft: WaitingForReply/29.01.2020
            //P&P (n2n FullStack .NET Developer): WaitingForInterviewDate/30.1 
        }
    }
}
