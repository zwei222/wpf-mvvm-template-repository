namespace MvvmCore.Models
{
    /// <summary>
    /// Interface that is the base of the dialog element in the Model layer of MVVM.
    /// </summary>
    public interface IDialogModelBase : IModelBase
    {
        /// <summary>
        /// Gets or sets the height of the dialog.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the width of the dialog.
        /// </summary>
        public double Width { get; set; }
    }
}
