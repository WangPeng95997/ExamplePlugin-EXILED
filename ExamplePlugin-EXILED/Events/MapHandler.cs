using Exiled.Events.EventArgs.Map;

namespace ExamplePlugin.Events
{
    public class MapHandler
    {
        public MapHandler() { }

        // 禁用血迹
        internal void OnPlacingBlood(PlacingBloodEventArgs ev)
        {
            ev.IsAllowed = false;
        }
    }
}