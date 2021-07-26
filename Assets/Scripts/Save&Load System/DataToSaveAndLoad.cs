namespace NWR.Modules
{
    [System.Serializable]
    public class DataToSaveAndLoad
    {
        public uint money;
        public ushort selectedCarID;
        public ushort selectedRoadID;
        public ushort selectedGameModeID;

        public int[] ID_OfAllPurchasedCars;
        public int[] ID_OfAllPurchasedRoads;

        public DataToSaveAndLoad()
        {
            money = Player.Instance.money;

            selectedCarID = Player.Instance.selectedCarID;
            selectedRoadID = Player.Instance.selectedRoadID;
            selectedGameModeID = Player.Instance.selectedGameModeID;

            ID_OfAllPurchasedCars = Player.Instance.listOfPurchasedItemIDs.boughtCars.ToArray();
            ID_OfAllPurchasedRoads = Player.Instance.listOfPurchasedItemIDs.boughtRoads.ToArray();
        }
    }
}