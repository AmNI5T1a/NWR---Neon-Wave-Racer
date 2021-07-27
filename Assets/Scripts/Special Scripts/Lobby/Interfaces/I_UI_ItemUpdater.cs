using NWR.Modules;

namespace NWR.Lobby
{
    public interface I_UI_ItemUpdater
    {
        void UpdateUIComponent<T>(Assets.ItemAndStats<T> instance) where T : Item;
    }
}