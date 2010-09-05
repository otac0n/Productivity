namespace EventsLibrary
{
    public interface IEventSourceFactory : IPluginFactory
    {
        IEventSource CreateInstance(string settings);

        string Configure(string currentSettings);
    }
}
