namespace NWR.Modules
{
    public interface I_UI_CreateDeleteItem
    {
        void CreateItem(Assets.OnSendItemsEventArgs items);
        void DeleteItem<T>(T item) where T : Item;
    }
}