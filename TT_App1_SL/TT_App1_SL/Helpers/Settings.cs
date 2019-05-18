// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace TT_App1_SL.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        private static readonly string SettingsDefault = string.Empty;

        public static string userName
        {
            get
            {
                return AppSettings.GetValueOrDefault("userName", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("userName", value);
            }
        }
        public static string password
        {
            get
            {
                return AppSettings.GetValueOrDefault("password", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("password", value);
            }
        }

        public static string accessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("accessToken", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("accessToken", value);
            }
        }

        public static string modoPeaton
        {
            get
            {
                return AppSettings.GetValueOrDefault("modoPeaton", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("modoPeaton", value);
            }
        }

        public static string distancia
        {
            get
            {
                return AppSettings.GetValueOrDefault("distancia", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("distancia", value);
            }
        }
        public static string tiempo
        {
            get
            {
                return AppSettings.GetValueOrDefault("tiempo", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("tiempo", value);
            }
        }
    }
}