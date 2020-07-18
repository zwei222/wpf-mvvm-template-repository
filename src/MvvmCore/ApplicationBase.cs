using System;
using DryIoc;
using Microsoft.Extensions.Logging;
using Prism.DryIoc;

namespace MvvmCore
{
    /// <summary>
    /// Abstract application class that is the base of App.xaml.cs.
    /// </summary>
    public abstract class ApplicationBase : PrismApplication
    {
        /// <summary>
        /// 
        /// </summary>
        private ILoggerFactory? loggerFactory;

        /// <summary>
        /// Create an ILogger instance from the set ILoggerFactory.
        /// </summary>
        /// <typeparam name="T">Type name to be injected into the created ILogger instance</typeparam>
        /// <returns>The created ILogger instance</returns>
        protected virtual ILogger<T>? CreateLogger<T>()
        {
            return this.loggerFactory?.CreateLogger<T>();
        }

        /// <summary>
        /// Configure the logger with a logging provider delegate.
        /// </summary>
        /// <param name="configure">A delegate to configure the <c>ILoggingBuilder</c></param>
        protected virtual void SetLogger(Action<ILoggingBuilder> configure)
        {
            this.loggerFactory = LoggerFactory.Create(configure);
            var container = this.Container.GetContainer();
            var loggerFactoryMethod =
                typeof(LoggerFactoryExtensions).GetMethod(nameof(LoggerFactoryExtensions.CreateLogger),
                    new[] { typeof(ILoggerFactory) });

            container.UseInstance(loggerFactory);
            container.Register(typeof(ILogger<>),
                made: Made.Of(request => loggerFactoryMethod!.MakeGenericMethod(request.Parent.ImplementationType)));
        }
    }
}
