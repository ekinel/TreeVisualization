using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var FirstVariant = new TreeVisualization(@"https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/config.xml");

            //var SecondVariant = new TreeVisualization();
            //SecondVariant.DownloadXmlDocument(@"https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/tree.xml");
            //SecondVariant.OpenXmlDocument();
            //SecondVariant.DisplayXmlTree();
            //SecondVariant.DeleteXmlDocument();
        }
    }
}
