using System.Text.Json.Serialization;

namespace Toolkit.Blazor.Extensions.File.Entities;

/// <summary>
/// Represents binary data with associated MIME type and optional metadata.
/// </summary>
/// <param name="Bytes">The raw binary data bytes</param>
/// <param name="MimeType">The MIME type describing the binary content format</param>
/// <remarks>
/// This record is typically used to encapsulate file data or binary content that needs to be
/// transferred with type information. The <see cref="Metadata"/> property can be used to
/// store additional information about the binary content.
/// </remarks>
public record Binary(byte[] Bytes, string MimeType)
{
    /// <summary>
    /// Gets or sets the raw binary data.
    /// </summary>
    /// <value>The byte array containing the binary content.</value>
    public byte[] Bytes { get; set; } = Bytes;
    
    /// <summary>
    /// Gets or sets optional metadata associated with the binary content.
    /// </summary>
    /// <value>
    /// A dictionary of key-value pairs containing additional information about the binary data.
    /// This property is ignored during JSON serialization.
    /// </value>
    /// <remarks>
    /// Common metadata might include:
    /// - Original file name
    /// - Creation date
    /// - Content dimensions (for images/videos)
    /// - Checksums or hashes
    /// </remarks>
    [JsonIgnore]
    public Dictionary<string, string>? Metadata { get; set; }
}