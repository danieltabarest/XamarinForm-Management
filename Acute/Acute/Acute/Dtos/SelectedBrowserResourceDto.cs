using System;
namespace MyLearn.Dtos
{
    public class SelectedBrowserResourceDto
    {
        public Uri Url
        {
            get;
            private set;
        }

        public string Title
        {
            get;
            private set;
        }

        public SelectedBrowserResourceDto(Uri url, string title)
        {
            Url = url;
            Title = title;
        }

        public SelectedBrowserResourceDto(Uri url) : this(url, "In App Browser")
        {
        }
    }
}
