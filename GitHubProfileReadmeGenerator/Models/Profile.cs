/*
 * -----------------------------------------------------------------------------
 *  Project:    GitHub Profile README Generator
 *  File:       Profile.cs
 *  Author:     Behnam Panahi (https://github.com/aboutbehnam)
 *  Date:       2025-05-18
 * -----------------------------------------------------------------------------
 *  Description:
 *      The main data model for the application. It encapsulates all the
 *      information required to generate a GitHub profile README file.
 *      Inherits from BaseViewModel to support data binding for all profile properties.
 * -----------------------------------------------------------------------------
 */

using GitHubProfileReadmeGenerator.ViewModels; // For BaseViewModel
using System.Collections.ObjectModel; // Required for ObservableCollection

namespace GitHubProfileReadmeGenerator.Models
{
    /// <summary>
    /// Represents all the data associated with a user's GitHub profile.
    /// </summary>
    public class Profile : BaseViewModel
    {
        private string _name;
        private string _tagline;
        private string _aboutMe;
        private string _githubUsername;
        private bool _showGitHubStats = true;
        private bool _showTopLanguages = true;

        /// <summary>
        /// Gets or sets the user's full name or display name.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Gets or sets a short, catchy tagline or role description.
        /// e.g., "Full-Stack Developer | Tech Enthusiast"
        /// </summary>
        public string Tagline
        {
            get => _tagline;
            set => SetProperty(ref _tagline, value);
        }

        /// <summary>
        /// Gets or sets the main "About Me" section content, which can be a longer text.
        /// </summary>
        public string AboutMe
        {
            get => _aboutMe;
            set => SetProperty(ref _aboutMe, value);
        }

        /// <summary>
        /// Gets or sets the user's GitHub username, used for generating stats cards.
        /// </summary>
        public string GitHubUsername
        {
            get => _githubUsername;
            set => SetProperty(ref _githubUsername, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to include the GitHub stats card.
        /// </summary>
        public bool ShowGitHubStats
        {
            get => _showGitHubStats;
            set => SetProperty(ref _showGitHubStats, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to include the top languages card.
        /// </summary>
        public bool ShowTopLanguages
        {
            get => _showTopLanguages;
            set => SetProperty(ref _showTopLanguages, value);
        }

        /// <summary>
        /// Gets or sets a collection of the user's technology skills and tools.
        /// </summary>
        public ObservableCollection<SocialLink> Skills { get; set; }

        /// <summary>
        /// Gets or sets a collection of the user's social media links.
        /// </summary>
        public ObservableCollection<SocialLink> Socials { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Profile"/> class.
        /// </summary>
        public Profile()
        {
            // Initialize collections to ensure they are never null.
            Skills = new ObservableCollection<SocialLink>();
            Socials = new ObservableCollection<SocialLink>();
        }
    }
}