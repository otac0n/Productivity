using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    /// <summary>
    /// Describes an Actions event.
    /// </summary>
    public class ActionsEventArgs : EventArgs
    {
        /// <summary>
        /// Holds the Actions specific to this event.
        /// </summary>
        private IList<EventAction> actions;

        /// <summary>
        /// Initializes a new instance of the ActionsEventArgs class with the specified Actions.
        /// </summary>
        /// <param name="actions">The Actions specific to this event.</param>
        public ActionsEventArgs(IEnumerable<EventAction> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }

            this.actions = actions.ToList().AsReadOnly();
        }

        /// <summary>
        /// Gets the Actions specific to this event.
        /// </summary>
        public IList<EventAction> Actions
        {
            get
            {
                return this.actions;
            }
        }
    }
}
