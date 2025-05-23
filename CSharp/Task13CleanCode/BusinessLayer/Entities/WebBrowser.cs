﻿using System.Text.Json.Serialization;

namespace BusinessLayer.Entities;

public class WebBrowser
{
    public BrowserName Name { get; set; }
    public int MajorVersion { get; set; }

    public WebBrowser(string name, int majorVersion)
    {
        Name = TranslateStringToBrowserName(name);
        MajorVersion = majorVersion;
    }

    private BrowserName TranslateStringToBrowserName(string name)
    {
        if (name.Contains("IE")) return BrowserName.InternetExplorer;
        //TODO: Add more logic for properly sniffing for other browsers.
        return BrowserName.Unknown;
    }

    public enum BrowserName
    {
        Unknown,
        InternetExplorer,
        Firefox,
        Chrome,
        Opera,
        Safari,
        Dolphin,
        Konqueror,
        Linx
    }
}