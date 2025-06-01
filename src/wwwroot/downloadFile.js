/**
 * Triggers a file download in the browser with the specified content.
 *
 * @param {string} filename - The name to give the downloaded file
 * @param {string} contentType - The MIME type of the file content
 * @param {BlobPart} content - The binary content of the file to download
 *
 * @example
 * // Download a simple text file
 * file('document.txt', 'text/plain', 'Hello world');
 *
 * @example
 * // Download a PDF from binary data
 * file('report.pdf', 'application/pdf', pdfBytes);
 *
 * @remarks
 * This function:
 * 1. Creates a File object from the content
 * 2. Generates an object URL for the file
 * 3. Programmatically clicks an anchor element to trigger download
 * 4. Cleans up the object URL after download
 *
 * Note: Some older versions of Safari may require removing the URL.revokeObjectURL()
 * call to ensure the download completes successfully.
 */
export function file(filename, contentType, content) {
    // Create the URL
    const file = new File([content], filename, {type: contentType});
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object URL, let's release the memory
    // On older versions of Safari, it seems you need to comment this line...
    URL.revokeObjectURL(exportUrl);
}