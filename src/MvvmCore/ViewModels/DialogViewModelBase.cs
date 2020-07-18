using System;
using MvvmCore.Models;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MvvmCore.ViewModels
{
    /// <summary>
    /// The base class for dialog elements in the ViewModel layer of MVVM.
    /// </summary>
    /// <typeparam name="TModel">The model layer type name to be injected into this instance</typeparam>
    public abstract class DialogViewModelBase<TModel> : ViewModelBase, IDialogAware
        where TModel : IDialogModelBase
    {
        /// <inheritdoc />
        public event Action<IDialogResult>? RequestClose;

        /// <summary>
        /// Create an instance that is the basis of the MVVM ViewModel layer.
        /// </summary>
        /// <param name="model">Model layer object to be injected into this instance</param>
        protected DialogViewModelBase(TModel model)
        {
            this.Model = model;
            this.Title = string.Empty;
            this.Height = this.Model.ToReactivePropertyAsSynchronized(myModel => myModel.Height).AddTo(this.Disposable);
            this.Width = this.Model.ToReactivePropertyAsSynchronized(myModel => myModel.Width).AddTo(this.Disposable);
        }

        /// <inheritdoc />
        public string Title { get; }

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

        /// <inheritdoc />
        public virtual bool CanCloseDialog() => true;

        /// <inheritdoc />
        public virtual void OnDialogClosed()
        {
        }

        /// <inheritdoc />
        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }

        /// <summary>
        /// Close the dialog.
        /// </summary>
        /// <param name="dialogResult">Dialog processing result</param>
        protected virtual void CloseDialog(IDialogResult dialogResult)
        {
            this.RequestClose?.Invoke(dialogResult);
        }
    }
}
