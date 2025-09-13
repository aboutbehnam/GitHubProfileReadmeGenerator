/*
 * -----------------------------------------------------------------------------
 *  Project:    GitHub Profile README Generator
 *  File:       MainWindow.xaml.cs
 *  Author:     Behnam Panahi (https://github.com/aboutbehnam)
 *  Date:       2025-05-21
 * -----------------------------------------------------------------------------
 *  Description:
 *      The code-behind for the main application window. In a pure MVVM
 *      approach, this file should contain minimal to no logic. Its primary
 *      responsibility is to initialize the window and set its DataContext
 *      to the corresponding ViewModel.
 * -----------------------------------------------------------------------------
 */

using GitHubProfileReadmeGenerator.ViewModels;
using System.Windows;

namespace GitHubProfileReadmeGenerator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the DataContext of the Window to our MainViewModel.
            // This is the crucial step that connects the View to the ViewModel.
            DataContext = new MainViewModel();
        }
    }
}