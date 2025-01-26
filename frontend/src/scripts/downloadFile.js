export default function downloadFile(contents, fileName, contentType = "text/plain") {
    const blob = new Blob([contents], { type: contentType });
    const link = document.createElement("a");

    link.href = URL.createObjectURL(blob);
    link.download = fileName;
    link.click();
}
