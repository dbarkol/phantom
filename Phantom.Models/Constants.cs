using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Phantom.Models
{
    /// <summary>
    /// This file contains a collection of constants for common values
    /// used through the solution. It is recommended that we reference
    /// these constants instead of editing string values throughout 
    /// the project.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Engine types
        /// </summary>
        public static class EngineTypes
        {
            public static string Trent900 = "Trent900";
            public static string Trent1000 = "Trent1000";
            public static string Trent7000 = "Trent7000";
        }

        /// <summary>
        /// Metadata about an engine
        /// </summary>
        public static class Tags
        {
            public static string DeltaRefresh = "DeltaRefresh";
            public static string NonMilitary = "NonMilitary";
            public static string ExportControlled = "ExportControlled";
            public static string BusinessSharing = "BusinessSharing";
        }

        /// <summary>
        /// Event types for custom topics
        /// </summary>
        public static class EventTypes
        {
            public static string NewFile = "Phantom.EventType.NewFile";
            public static string DeletedFile = "Phantom.EventType.DeletedFile";
        }
    }
}