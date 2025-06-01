using Microsoft.AspNetCore.Components;

namespace Toolkit.Blazor.Extensions.File.Utilities;

/// <summary>
/// A Blazor component that captures and processes unmatched parameters passed to a component.
/// This is useful for forwarding arbitrary HTML attributes to child components or handling dynamic attributes.
/// </summary>
public class CaptureUnmatchedParameters : ComponentBase
{
    /// <summary>
    /// Gets a dictionary containing all unmatched parameters except the "class" attribute.
    /// This is populated during <see cref="OnParametersSet"/> with all attributes that don't match
    /// declared parameters, excluding the "class" attribute.
    /// </summary>
    protected IReadOnlyDictionary<string, object>? Attributes;
    
    /// <summary>
    /// Gets the value of the unmatched "class" attribute, if one was provided.
    /// This is populated during <see cref="OnParametersSet"/> by extracting the "class" attribute
    /// from the unmatched parameters.
    /// </summary>
    protected string? Classes;
    
    /// <summary>
    /// Gets or sets a dictionary of all unmatched parameters passed to the component.
    /// This property captures all attributes that don't match declared parameters due to
    /// the <see cref="ParameterAttribute.CaptureUnmatchedValues"/> being set to true.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] 
    public IReadOnlyDictionary<string, object> UnmatchedParameters { get; set; } = new Dictionary<string, object>();
    
    /// <summary>
    /// Processes the component parameters when they are set.
    /// </summary>
    /// <remarks>
    /// This method:
    /// 1. Calls the base implementation
    /// 2. Extracts the "class" attribute value into <see cref="Classes"/>
    /// 3. Stores all other unmatched attributes in <see cref="Attributes"/>
    /// </remarks>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    
        // extract class attribute
        Classes = $"{UnmatchedParameters.GetValueOrDefault("class")}";
    
        // extract non-class attributes
        Attributes =
            UnmatchedParameters
                .Where(x => x.Key != "class")
                .ToDictionary(k => k.Key, v => v.Value);
    }
}