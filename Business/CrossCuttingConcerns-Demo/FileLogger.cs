using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CrossCuttingConcerns_Demo
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya loglandı.");
        }
    }
}
