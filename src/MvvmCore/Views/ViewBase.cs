﻿using System;
using System.Windows;
using Prism.Mvvm;

namespace MvvmCore.Views
{
    /// <summary>
    /// The class that is the base of the View layer of MVVM.
    /// </summary>
    public abstract class ViewBase : Window
    {
        /// <summary>
        /// Create an instance that is the basis of the MVVM View layer.
        /// </summary>
        protected ViewBase()
        {
            ViewModelLocator.SetAutoWireViewModel(this, true);
        }

        /// <inheritdoc />
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this.DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
