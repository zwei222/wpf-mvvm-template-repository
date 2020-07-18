using System;

namespace MvvmCore.Core
{
    public abstract class AbstractedDisposable : IDisposable
    {
        /// <summary>
        /// <see langword="true" /> if the resource has been released; otherwise <see langword="false" />.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a managed resource.
        /// </summary>
        protected virtual void DisposeManaged()
        {
        }

        /// <summary>
        /// Dispose a unmanaged resource.
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {
        }

        /// <summary>
        /// Release the used resources.
        /// </summary>
        /// <param name="disposing"><see langword="true" /> if release explicitly; otherwise <see langword="false" /></param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            this.DisposeUnmanaged();

            if (disposing)
            {
                this.DisposeManaged();
            }

            this.IsDisposed = true;
        }
    }
}
