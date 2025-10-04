using Microsoft.Extensions.Configuration;
using ToDoList.Core.Interfaces.Services;

namespace ToDoList.Infrastructure.Services
{
    public class LogServices(IConfiguration configuration) : ILogServices
    {
        private readonly IConfiguration _configuration = configuration;


        public void SaveLogsMessages(string messages)
        {
            string filePath = _configuration["PathLogs"] ?? "";
            var directoryPath = Path.GetDirectoryName(filePath) ?? "";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (File.Exists(filePath) && new FileInfo(filePath).Length > 100 * 1024 * 1024)
            {
                File.Delete(filePath);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}] ---- {messages}");
            }
        }
    }
}
