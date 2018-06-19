using System;
using System.Collections.Generic;
using System.Text;

namespace Phantom.Models
{
    /// <summary>
    /// This class encapsulates the metadata for an event 
    /// related to an engine. It will contain the original
    /// storage event data along with additional information
    /// that is contextual to the engine itself.
    /// </summary>
    public class EngineEvent
    {
        /// <summary>
        /// The name of the engine type
        /// </summary>
        public string EngineType { get; set; }

        /// <summary>
        /// A list of tags that are related to the
        /// instance of the engine.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// The original payload that was sent
        /// from the storage event.
        /// </summary>
        public object StorageEventData { get; set; }

    }
}
