using Prism.Mvvm;

namespace MvvmCore.Models.Implementations
{
    /// <summary>
    /// The base class for dialog elements in the Model layer of MVVM.
    /// </summary>
    public abstract class DialogModelBase : BindableBase, IDialogModelBase
    {
        /// <summary>
        /// The height of the dialog.
        /// </summary>
        private double height;

        /// <summary>
        /// The width of the dialog.
        /// </summary>
        private double width;

        /// <summary>
        /// Creates an instance of the model with the dialog height and width initialized.
        /// </summary>
        /// <param name="height">The height of the dialog</param>
        /// <param name="width">The width of the dialog</param>
        protected DialogModelBase(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        /// <inheritdoc />
        public double Height
        {
            get => this.height;
            set => this.SetProperty(ref this.height, value);
        }

        /// <inheritdoc />
        public double Width
        {
            get => this.width;
            set => this.SetProperty(ref this.width, value);
        }
    }
}
