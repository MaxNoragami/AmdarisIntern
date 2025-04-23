using BusinessLayer.Entities;
using PresentationLayer.Dtos;

namespace PresentationLayer.Mappers;

public static class WebBrowserMappers
{
    public static WebBrowser ToWebBrowser(this WebBrowserDto webBrowserDto)
        => new WebBrowser(webBrowserDto.Name ?? "Unknown", webBrowserDto.MajorVersion);
}
