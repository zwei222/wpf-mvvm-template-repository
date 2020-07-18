using System.Reactive.Disposables;
using MvvmCore.Core;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reactive.Bindings.Notifiers;

namespace MvvmCore.ViewModels
{
    /// <summary>
    /// The class that is the base of the ViewModel layer of MVVM.
    /// </summary>
    public abstract class ViewModelBase : AbstractedDisposable
    {
        /// <summary>
        /// Create an instance that is the basis of the MVVM ViewModel layer.
        /// </summary>
        protected ViewModelBase()
        {
            this.Disposable = new CompositeDisposable();
            this.BusyNotifier = new BusyNotifier();
            this.IsBusy = this.BusyNotifier.ToReadOnlyReactivePropertySlim().AddTo(this.Disposable);
        }

        /// <summary>
        /// <see langword="true" /> if busy; otherwise <see langword="false" />.
        /// </summary>
        public ReadOnlyReactivePropertySlim<bool> IsBusy { get; }

        /// <summary>
        /// Busy status notification object.
        /// </summary>
        protected BusyNotifier BusyNotifier { get; }

        /// <summary>
        /// An object that manages the objects that need to release resources with a composite.
        /// </summary>
        protected CompositeDisposable Disposable { get; }

        /// <inheritdoc />
        protected override void DisposeManaged()
        {
            base.DisposeManaged();
            this.Disposable.Dispose();
        }
    }
}
