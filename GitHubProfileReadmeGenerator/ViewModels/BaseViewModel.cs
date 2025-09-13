/*
 * -----------------------------------------------------------------------------
 *  Project:    GitHub Profile README Generator
 *  File:       BaseViewModel.cs
 *  Author:     Behnam Panahi (https://github.com/aboutbehnam)
 *  Date:       2025-05-18
 * -----------------------------------------------------------------------------
 *  Description:
 *      A base class for all ViewModels to provide common functionality,
 *      specifically implementing the INotifyPropertyChanged interface to
 *      support data binding in a clean and reusable way.
 * -----------------------------------------------------------------------------
 */

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GitHubProfileReadmeGenerator.ViewModels
{
    /// <summary>
    /// A base class for objects that need to notify clients when a property value changes.
    /// Implements INotifyPropertyChanged.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property used to notify listeners. This value is optional and can be provided
        /// automatically when invoked from compilers that support CallerMemberName.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// A helper method to set a property and raise the PropertyChanged event only if the value has changed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">The new value for the property.</param>
        /// <param name="propertyName">
        /// Name of the property used to notify listeners. This value is optional and can be provided
        /// automatically when invoked from compilers that support CallerMemberName.
        /// </param>
        /// <returns>True if the value was changed, false otherwise.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}