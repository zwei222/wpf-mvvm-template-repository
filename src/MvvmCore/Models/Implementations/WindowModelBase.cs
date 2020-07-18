using Prism.Mvvm;

namespace MvvmCore.Models.Implementations
{
    /// <summary>
    /// The base class for window elements in the Model layer of MVVM.
    /// </summary>
    public abstract class WindowModelBase : BindableBase, IWindowModelBase
    {
        /// <summary>
        /// The title of the window.
        /// </summary>
        private string? title;

        /// <summary>
        /// The height of the window.
        /// </summary>
        private double height;

        /// <summary>
        /// The width of the window.
        /// </summary>
        private double width;

        /// <summary>
        /// Creates an instance of the model with the window height and width initialized.
        /// </summary>
        /// <param name="height">The height of the window</param>
        /// <param name="width">The width of the window</param>
        protected WindowModelBase(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        /// <inheritdoc />
        public string? Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
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
