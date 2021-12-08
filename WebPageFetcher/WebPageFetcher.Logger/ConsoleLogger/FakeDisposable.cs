using System;

namespace WebPageFetcher.Logger
{
    /// <summary>
    /// For the <see cref="ConsoleLogger"/> to provide a scope object
    /// </summary>
    internal class FakeDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
