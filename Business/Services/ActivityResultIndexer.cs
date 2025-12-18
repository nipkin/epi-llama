using EPiServer.Find;
using epiv12demo.Models.Index;

namespace epiv12demo.Business.Services
{
    public class ActivityResultIndexer(IClient findClient)
    {
        private readonly IClient _findClient = findClient ?? throw new ArgumentNullException(nameof(findClient));

        public async Task IndexAsync(string userInput, string result)
        {
            var entry = new ActivityResultIndex
            {
                UserInput = userInput,
                Result = result,
                Timestamp = DateTime.UtcNow
            };

            await _findClient.IndexAsync(entry);
        }
    }
}