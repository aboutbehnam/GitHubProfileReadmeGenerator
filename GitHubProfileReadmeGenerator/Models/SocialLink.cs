/*
 * -----------------------------------------------------------------------------
 *  Project:    GitHub Profile README Generator
 *  File:       SocialLink.cs
 *  Author:     Behnam Panahi (https://github.com/aboutbehnam)
 *  Date:       2025-05-18
 * -----------------------------------------------------------------------------
 *  Description:
 *      Represents a single social media link or skill badge. This model is
 *      designed to be data-bound in the UI, hence it inherits from
 *      BaseViewModel to notify the UI of property changes.
 * -----------------------------------------------------------------------------
 */

using GitHubProfileReadmeGenerator.ViewModels; // For inheriting from BaseViewModel

namespace GitHubProfileReadmeGenerator.Models
{
    /// <summary>
    /// Represents a social media profile link or a technology skill badge.
    /// </summary>
    public class SocialLink : BaseViewModel
    {
        private string _platformName;
        private string _url;
        private string _badgeUrl;

        /// <summary>
        /// Gets or sets the name of the social media platform or technology.
        /// e.g., "LinkedIn", "Twitter", "C#".
        /// </summary>
        public string PlatformName
        {
            get => _platformName;
            set => SetProperty(ref _platformName, value);
        }

        /// <summary>
        /// Gets or sets the full URL to the user's profile on the platform.
        /// </summary>
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        /// <summary>
        /// Gets or sets the URL for the markdown badge/icon.
        /// This is often retrieved from services like shields.io.
        /// </summary>
        public string BadgeUrl
        {
            get => _badgeUrl;
            set => SetProperty(ref _badgeUrl, value);
        }
    }
}