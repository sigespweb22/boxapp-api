using System;
using System.Collections.Generic;

namespace BoxBack.Application.ViewModels.Navigation
{
    public class VerticalNavItemViewModel
    {
        public string Icon { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Subject { get; set; }
        public bool Disabled { get; set; }
        public string BadgeContent { get; set; }
        public bool ExternalLing { get; set; }
        public bool OpenInNewTab { get; set; }
        public string BadgeColor { get; set; }
        public string SectionTitle { get; set; }
        public List<Son> Children { get; set; }
    }

    public class Son
    {
        public string Icon { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Subject { get; set; }
        public bool Disabled { get; set; }
        public string BadgeContent { get; set; }
        public bool ExternalLing { get; set; }
        public bool OpenInNewTab { get; set; }
        public string BadgeColor { get; set; }
        public List<Son> Children { get; set; }
    }
}