/*
 * -----------------------------------------------------------------------------
 *  Project:    GitHub Profile README Generator
 *  File:       App.xaml.cs
 *  Author:     Behnam Panahi (https://github.com/aboutbehnam)
 *  Date:       2025-05-22
 * -----------------------------------------------------------------------------
 *  Description:
 *      The main application class. Responsible for startup and global
 *      application-level concerns, such as theme management. It provides
 *      a public method to dynamically change the loaded theme.
 * -----------------------------------------------------------------------------
 */
using System;
using System.Linq;
using System.Windows;

namespace GitHubProfileReadmeGenerator
{
    /// <summary>
    /// Defines the available themes for the application.
    /// </summary>
    public enum AppTheme
    {
        Light,
        Dark,
        Colorful
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Changes the application's current theme by swapping ResourceDictionaries.
        /// </summary>
        /// <param name="theme">The new theme to apply.</param>
        public void ChangeTheme(AppTheme theme)
        {
            // Find the URI of the currently loaded theme dictionary.
            // We identify it by checking if the source URI contains "Styles", which is unique to our theme files.
            var oldTheme = Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Styles"));

            if (oldTheme != null)
            {
                // Remove the old theme dictionary.
                Resources.MergedDictionaries.Remove(oldTheme);
            }

            // Construct the URI for the new theme file.
            var themeUri = new Uri($"/Resources/Styles/{theme}.xaml", UriKind.Relative);
            var newTheme = new ResourceDictionary { Source = themeUri };

            // Add the new theme dictionary to the application's resources.
            Resources.MergedDictionaries.Add(newTheme);
        }
    }
}