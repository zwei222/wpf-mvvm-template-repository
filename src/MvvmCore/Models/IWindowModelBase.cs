namespace MvvmCore.Models
{
    /// <summary>
    /// Interface that is the base of the window element in the Model layer of MVVM.
    /// </summary>
    public interface IWindowModelBase : IModelBase
    {
        /// <summary>
        /// Gets or sets the title of the window.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the height of the window.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the width of the window.
        /// </summary>
        public double Width { get; set; }
    }
}
