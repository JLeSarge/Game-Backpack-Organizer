namespace GameBackPackOrganizer.GameEngine
{
    public class BackPack
    {
        public BackPackSlot[5][4] slot{get; set;}

        public BackPack(item[][] items)
        {
            for(int i=0;i<items.Length(0);i++)
            {
                for(int j=0;j<items.Length(1);j++)
                {
                    slot[i][j].slottedItem = items[i][j];
                }
            }
        }
    }
    public class BackPackSlot
    {
        public int slotID{get; set;}
        public item slottedItem{get; set;}
    }
    public class item 
    {
        public int itemID{get; set;}
        public int itemValue{get; set;}
    }
}