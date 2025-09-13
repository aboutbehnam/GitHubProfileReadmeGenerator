/*
 * -----------------------------------------------------------------------------
 *  Project:    GitHub Profile README Generator
 *  File:       MainViewModel.cs
 *  Author:     Behnam Panahi (https://github.com/aboutbehnam)
 *  Date:       2025-05-22
 * -----------------------------------------------------------------------------
 *  Description:
 *      The primary ViewModel for the main window. It acts as the central hub
 *      for the application's logic and data. It holds the user's profile data,
 *      exposes commands for UI interactions (like generating the README),
 *      and manages the application's state, including appearance settings.
 * -----------------------------------------------------------------------------
 */

using GitHubProfileReadmeGenerator.Core.Utils;
using GitHubProfileReadmeGenerator.Models;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace GitHubProfileReadmeGenerator.ViewModels
{
    /// <summary>
    /// The main ViewModel for the application, handling all UI logic and data management.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields

        private Profile _userProfile;
        private string _generatedReadme;
        private double _previewFontSize = 14; // Default font size

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the active user profile object.
        /// </summary>
        public Profile UserProfile
        {
            get => _userProfile;
            set => SetProperty(ref _userProfile, value);
        }

        /// <summary>
        /// Gets or sets the generated README markdown text.
        /// </summary>
        public string GeneratedReadme
        {
            get => _generatedReadme;
            set => SetProperty(ref _generatedReadme, value);
        }

        /// <summary>
        /// Gets or sets the font size for the README preview TextBox.
        /// </summary>
        public double PreviewFontSize
        {
            get => _previewFontSize;
            set => SetProperty(ref _previewFontSize, value);
        }

        #endregion

        #region Commands

        public ICommand GenerateReadmeCommand { get; }
        public ICommand CopyReadmeCommand { get; }
        public ICommand AddSkillCommand { get; }
        public ICommand RemoveSkillCommand { get; }
        public ICommand AddSocialCommand { get; }
        public ICommand RemoveSocialCommand { get; }
        public ICommand ChangeThemeCommand { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            // Initialize the profile with some default, helpful data for the user.
            UserProfile = new Profile
            {
                Name = "Behnam Panahi",
                Tagline = "Software Developer | Tech Enthusiast",
                GitHubUsername = "aboutbehnam",
                AboutMe = "Hi there! I'm a passionate developer who loves building amazing things.\nWelcome to my profile!"
            };

            // Load some sample skills and socials to guide the user.
            LoadDefaultSkillsAndSocials();

            // Initialize commands
            GenerateReadmeCommand = new RelayCommand(GenerateReadme);
            CopyReadmeCommand = new RelayCommand(CopyReadme, CanCopyReadme);
            AddSkillCommand = new RelayCommand(AddSkill);
            RemoveSkillCommand = new RelayCommand(RemoveSkill);
            AddSocialCommand = new RelayCommand(AddSocial);
            RemoveSocialCommand = new RelayCommand(RemoveSocial);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The core logic for generating the README markdown.
        /// </summary>
        private void GenerateReadme(object parameter)
        {
            var markdownBuilder = new StringBuilder();

            // --- Header ---
            markdownBuilder.AppendLine($"# Hi, I'm {UserProfile.Name} 👋");
            markdownBuilder.AppendLine($"### {UserProfile.Tagline}");
            markdownBuilder.AppendLine();

            // --- About Me ---
            markdownBuilder.AppendLine("## 🚀 About Me");
            markdownBuilder.AppendLine(UserProfile.AboutMe);
            markdownBuilder.AppendLine();

            // --- Skills ---
            markdownBuilder.AppendLine("## 🛠️ Skills & Tools");
            if (UserProfile.Skills.Count > 0)
            {
                foreach (var skill in UserProfile.Skills)
                {
                    markdownBuilder.Append($"![{skill.PlatformName}](https://img.shields.io/badge/{skill.PlatformName}-blue?style=for-the-badge&logo={skill.PlatformName.ToLower()}) ");
                }
                markdownBuilder.AppendLine("\n");
            }

            // --- Socials ---
            markdownBuilder.AppendLine("## 🔗 Connect with Me");
            if (UserProfile.Socials.Count > 0)
            {
                foreach (var social in UserProfile.Socials)
                {
                    markdownBuilder.Append($"<a href='{social.Url}' target='_blank'><img src='https://img.shields.io/badge/{social.PlatformName}-white?style=for-the-badge&logo={social.PlatformName.ToLower()}' alt='{social.PlatformName}'/></a> ");
                }
                markdownBuilder.AppendLine("\n");
            }

            // --- GitHub Stats ---
            if (UserProfile.ShowGitHubStats || UserProfile.ShowTopLanguages)
            {
                markdownBuilder.AppendLine("## 📊 GitHub Stats");
                if (UserProfile.ShowGitHubStats)
                {
                    markdownBuilder.AppendLine($"![{UserProfile.GitHubUsername}'s GitHub Stats](https://github-readme-stats.vercel.app/api?username={UserProfile.GitHubUsername}&show_icons=true&theme=radical)");
                }
                if (UserProfile.ShowTopLanguages)
                {
                    markdownBuilder.AppendLine($"![Top Languages](https://github-readme-stats.vercel.app/api/top-langs/?username={UserProfile.GitHubUsername}&layout=compact&theme=radical)");
                }
                markdownBuilder.AppendLine();
            }

            GeneratedReadme = markdownBuilder.ToString();
        }

        private void CopyReadme(object parameter)
        {
            Clipboard.SetText(GeneratedReadme);
        }

        private bool CanCopyReadme(object parameter)
        {
            return !string.IsNullOrWhiteSpace(GeneratedReadme);
        }

        private void AddSkill(object parameter)
        {
            UserProfile.Skills.Add(new SocialLink { PlatformName = "New Skill" });
        }

        private void RemoveSkill(object parameter)
        {
            if (parameter is SocialLink skillToRemove)
            {
                UserProfile.Skills.Remove(skillToRemove);
            }
        }

        private void AddSocial(object parameter)
        {
            UserProfile.Socials.Add(new SocialLink { PlatformName = "Platform", Url = "https://example.com" });
        }

        private void RemoveSocial(object parameter)
        {
            if (parameter is SocialLink socialToRemove)
            {
                UserProfile.Socials.Remove(socialToRemove);
            }
        }

        private void LoadDefaultSkillsAndSocials()
        {
            UserProfile.Skills.Add(new SocialLink { PlatformName = "CSharp" });
            UserProfile.Skills.Add(new SocialLink { PlatformName = "WPF" });
            UserProfile.Skills.Add(new SocialLink { PlatformName = "DotNet" });
            UserProfile.Skills.Add(new SocialLink { PlatformName = "Git" });

            UserProfile.Socials.Add(new SocialLink { PlatformName = "GitHub", Url = "https://github.com/aboutbehnam" });
            UserProfile.Socials.Add(new SocialLink { PlatformName = "LinkedIn", Url = "https://linkedin.com/in/your-username" });
        }

        /// <summary>
        /// Changes the application's visual theme by invoking a method on the App class.
        /// </summary>
        private void ChangeTheme(object parameter)
        {
            if (parameter is AppTheme theme)
            {
                if (Application.Current is App app)
                {
                    app.ChangeTheme(theme);
                }
            }
        }

        #endregion
    }
}