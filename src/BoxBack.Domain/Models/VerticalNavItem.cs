using System;
using System.Collections.Generic;

namespace BoxBack.Domain.Models
{
    public class VerticalNavItem : EntityAudit
    {
        public VerticalNavItem(string icon, string path, string title, string action,
                               string subject, bool disabled, string badgeContent, bool externalLink,
                               bool openInNewTab, string badgeColor, string sectionTitle, Int32 position, 
                               Guid levelMeKey, Guid levelUpKey)
        {
            Icon = icon;
            Title = title;
            Action = action;
            Subject = subject;
            Disabled = disabled;
            BadgeContent = badgeContent;
            ExternalLink = externalLink;
            OpenInNewTab = openInNewTab;
            BadgeColor = badgeColor;
            SectionTitle = sectionTitle;
            Position = position;
            LevelMeKey = levelMeKey;
            LevelUpKey = levelUpKey;
        }
        

        //Contructor empty to EFCore
        public VerticalNavItem() {}


        public string Icon { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Subject { get; set; }
        public bool Disabled { get; set; }
        public string BadgeContent { get; set; }
        public bool ExternalLink { get; set; }
        public bool OpenInNewTab { get; set; }
        public string BadgeColor { get; set; }
        public string SectionTitle { get; set; }
        public Int32 Position { get; set; }
        
        public Guid LevelMeKey { get; set; }
        public Guid LevelUpKey { get; set; }




        public List<VerticalNavItem> Children { get; set; }
    }
}