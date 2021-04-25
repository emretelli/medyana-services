using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Medyana.Services.XmlProducerConsoleApp
{
    public static class XmlReader
    {
        public static List<string> ReadXmlFiles()
        {
            string xmlFilesPath = @"C:\Projects\StaticFiles\XmlFiles";
            return Directory.EnumerateFiles(xmlFilesPath, "*.xml").ToList();
        }
    }
}
