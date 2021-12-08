using System.IO;
using System.Threading.Tasks;

namespace WebPageFetcher.Contracts
{
    /// <summary>
    /// A repository that saves to a local file
    /// </summary>
    public interface ILocalFileRepository
    {
        /// <summary>
        /// Saves the data stream to a local file
        /// Overwrites file if already exists
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="data">The data to write to the file</param>
        Task SaveFile(string path, Stream data);
    }
}
