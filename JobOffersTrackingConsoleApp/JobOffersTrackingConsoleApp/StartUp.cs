using Autofac;
using JOTCA.BusinessLayer.AutoConfig;
using JOTCA.BusinessLayer.Providers;

namespace JobOffersTrackingConsoleApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var container = ConfigurationBuilder.RunBuilder();
            var engine = container.Resolve<Engine>();
            engine.Run();
            


            //Accedia: Junior .NET Developer/WaitingForReply/29.01.2020
            //Soft2Run: WaitingForReply/29.01.2020
            //grafixoft: WaitingForReply/29.01.2020
            //P&P (M2MServices FullStack .NET Developer): WaitingForInterviewDate/30.1 
        }
    }
}
