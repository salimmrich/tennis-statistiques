using System.IO;
using System.Threading.Tasks;

namespace TennisStats.Infrastructure.Data
{
    public class JsonDataReader
    {
        public static async Task<string> ReadJsonFileAsync(string filePath)
        {
            return await File.ReadAllTextAsync(filePath);
        }
    }
}
