using MvvmCore.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MvvmCore.ViewModels
{
    /// <summary>
    /// The base class for window elements in the ViewModel layer of MVVM.
    /// </summary>
    /// <typeparam name="TModel">The model layer type name to be injected into this instance</typeparam>
    public abstract class WindowViewModelBase<TModel> : ViewModelBase
        where TModel : IWindowModelBase
    {
        /// <summary>
        /// Create an instance that is the basis of the MVVM ViewModel layer.
        /// </summary>
        /// <param name="model">Model layer object to be injected into this instance</param>
        protected WindowViewModelBase(TModel model)
        {
            this.Model = model;
            this.Title = this.Model.ObserveProperty(myModel => myModel.Title).ToReadOnlyReactivePropertySlim()
                .AddTo(this.Disposable);
            this.Height = this.Model.ToReactivePropertyAsSynchronized(myModel => myModel.Height).AddTo(this.Disposable);
            this.Width = this.Model.ToReactivePropertyAsSynchronized(myModel => myModel.Width).AddTo(this.Disposable);
        }

        /// <summary>
        /// Gets the title of the window.
        /// </summary>
        public ReadOnlyReactivePropertySlim<string?> Title { get; }

        /// <summary>
        /// Gets the height of the window.
        /// </summary>
        public ReactiveProperty<double> Height { get; }

        /// <summary>
        /// Gets the width of the window.
        /// </summary>
        public ReactiveProperty<double> Width { get; }

        /// <summary>
        /// Gets the model layer object to be injected into this instance.
        /// </summary>
        protected TModel Model { get; }
    }
}
