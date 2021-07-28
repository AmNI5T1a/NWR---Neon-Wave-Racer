using NWR.Modules;

namespace NWR.Lobby
{
    public interface I_UI_ItemUpdater
    {
        void UpdateUIComponent<T>(T item) where T : Item;
    }
}