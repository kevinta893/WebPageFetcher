using System.IO;
using System.Threading.Tasks;
using WebPageFetcher.Contracts;

namespace WebPageFetcher.FileRepository.Services
{
    public class LocalFileService : ILocalFileRepository
    {
        public async Task SaveFile(string path, Stream data)
        {
            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                data.Seek(0, SeekOrigin.Begin);
                data.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
    }
}
