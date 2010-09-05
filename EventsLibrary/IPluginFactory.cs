namespace EventsLibrary
{
    /// <summary>
    /// Describes the base interface for all plugin factories.
    /// </summary>
    /// <remarks>
    /// Each plugin factory must have a name, but may have creation
    /// methods with varing signatures.  Because of this, only the
    /// name can be read from a base plugin factory.
    /// </remarks>
    public interface IPluginFactory
    {
        /// <summary>
        /// Gets the name of this plugin factory.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
