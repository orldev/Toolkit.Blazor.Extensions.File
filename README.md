# Toolkit.Blazor.Extensions.File

Extension for the framework `Blazor`

## Installation

```bash
dotnet add package Snail.Toolkit.Blazor.Extensions.File
```

## Advanced Usage

```razor
<TExportFile Name="name_file" Binary="@Value">
    <p class="_wp">@context</p>
</TExportFile>

@code {
    [Parameter] public Binary? Value { get; set; }
}
```

```razor
<TImportFile OnUpload="@_onBinary" OnProgress="@_onProgress">
    <div class="_aa">
        @if (context)
        {
            <svg class="loader" viewBox="0 0 50 50">
                <circle class="path" cx="25" cy="25" r="20" fill="none" stroke-width="5"></circle>
            </svg> 
        }
        <p class="_ap">add file</p>
    </div>
</TImportFile>

@code {
    private async Task _onBinary(Binary binary) => await OnBinary.InvokeAsync(binary);

    private async Task _onProgress(int value)
    {
        _progress = value;
        await Task.Delay(1); // Simulate async work (e.g., updating UI)
    }
}
```

# Toolkit.Blazor.Extensions.File

A comprehensive file handling extension for Blazor applications, providing easy-to-use components for file import/export operations.

## Installation

```bash
dotnet add package Snail.Toolkit.Blazor.Extensions.File
```

## Features

- **File Export**: Download files with custom UI templates
- **File Import**: Upload files with progress tracking
- **Binary Handling**: Streamlined binary data management
- **Customizable UI**: Fully templatable components
- **Progress Tracking**: Real-time upload progress reporting

## Basic Usage

### File Export Component

```razor
<TExportFile Name="document.pdf" Binary="@pdfData">
    <button class="download-btn">
        Download PDF
    </button>
</TExportFile>

@code {
    private Binary? pdfData = new Binary(File.ReadAllBytes("sample.pdf"), "application/pdf");
}
```

### File Import Component

```razor
<TImportFile OnUpload="HandleFileUpload" OnProgress="UpdateProgress">
    <div class="upload-area">
        <span>Drag & drop files here</span>
    </div>
</TImportFile>

@code {
    private async Task HandleFileUpload(Binary file)
    {
        // Process uploaded file
    }
    
    private void UpdateProgress(int progress)
    {
        // Update UI with progress percentage
    }
}
```

## Advanced Usage

### Custom Export Template with Context

```razor
<TExportFile Name="report.docx" Binary="@reportData">
    <p class="file-info">
        <span>@context</span> <!-- Displays the filename -->
        <i class="download-icon"></i>
    </p>
</TExportFile>
```

### Import with Progress Indicator

```razor
<TImportFile OnUpload="@_onBinary" OnProgress="@_onProgress">
    <div class="upload-container">
        @if (context)  <!-- Context is true when uploading -->
        {
            <div class="progress-bar">
                <div style="width: @_progress%"></div>
            </div>
            <span>@_progress%</span>
        }
        else
        {
            <span>Select File</span>
        }
    </div>
</TImportFile>

@code {
    private int _progress;
    
    private async Task _onBinary(Binary binary) => await OnBinary.InvokeAsync(binary);

    private async Task _onProgress(int value)
    {
        _progress = value;
        StateHasChanged();
    }
}
```

## Component API Reference

### TExportFile

| Property | Type | Description |
|----------|------|-------------|
| Name | string | The filename for the exported file |
| Binary | Binary | The binary data to download |
| ChildContent | RenderFragment<string> | Template with filename context |

### TImportFile

| Property | Type | Description |
|----------|------|-------------|
| OnUpload | EventCallback<Binary> | Callback when file upload completes |
| OnProgress | EventCallback<int> | Progress percentage callback |
| ChildContent | RenderFragment<bool> | Template with upload state context |
| Multiple | bool | Allow multiple file uploads (default: false) |
| Accept | string | Accepted file types (e.g., ".pdf,.docx") |

## Best Practices

1. **Large Files**: For files > 50MB, consider chunked uploads
2. **Memory**: Dispose Binary objects after use

## License

Toolkit.Blazor.Extensions.File is a free and open source project, released under the permissible [MIT license](LICENSE).

