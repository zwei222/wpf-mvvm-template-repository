using System.Windows;
using Prism.Services.Dialogs;

namespace MvvmCore.Views
{
    /// <summary>
    /// The class that is the base of the View layer of MVVM.
    /// </summary>
    public abstract class DialogViewBase : ViewBase, IDialogWindow
    {
        /// <summary>
        /// Create an instance that is the basis of the MVVM View layer.
        /// </summary>
        protected DialogViewBase()
        {
            if (this.Owner == null && Application.Current.MainWindow != null)
            {
                this.Owner = Application.Current.MainWindow;
            }

            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            void LoadedHandler(object sender, RoutedEventArgs e)
            {
                if (this.DataContext is IDialogAware dialogAware && !string.IsNullOrEmpty(dialogAware.Title))
                {
                    this.Title = dialogAware.Title;
                }

                this.Loaded -= LoadedHandler;
            }

            this.Loaded += LoadedHandler;
        }

        /// <summary>
        /// Gets or sets the processing result of the dialog.
        /// </summary>
        public IDialogResult? Result { get; set; }
    }
}
