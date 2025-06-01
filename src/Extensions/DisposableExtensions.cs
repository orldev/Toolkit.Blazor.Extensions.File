using System.Reactive.Disposables;

namespace Toolkit.Blazor.Extensions.File.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="IDisposable"/> objects.
/// </summary>
public static class DisposableExtensions
{
    /// <summary>
    /// Adds an <see cref="IDisposable"/> resource to a <see cref="CompositeDisposable"/> collection.
    /// </summary>
    /// <typeparam name="T">The type of disposable resource, which must implement <see cref="IDisposable"/>.</typeparam>
    /// <param name="disposable">The disposable resource to add to the collection.</param>
    /// <param name="composite">The <see cref="CompositeDisposable"/> collection to which the resource will be added.</param>
    /// <remarks>
    /// This extension method provides a fluent syntax for adding disposables to a composite collection.
    /// Typical usage: <c>myDisposable.AddTo(compositeDisposables)</c>
    /// </remarks>
    /// <example>
    /// <code>
    /// var disposable = new SomeDisposable();
    /// var composite = new CompositeDisposable();
    /// disposable.AddTo(composite);
    /// </code>
    /// </example>
    public static void AddTo<T>(this T disposable, CompositeDisposable composite) 
        where T : IDisposable
    {
        composite.Add(disposable);
    }
}