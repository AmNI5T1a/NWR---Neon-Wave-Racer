using NWR.Modules;

namespace NWR.Lobby
{
    public interface I_UI_ItemCreator
    {
        void CreateItemsAtStart(Assets.OnSendAssetsEventArgs assets);
    }
}