namespace GameBackPackOrganizer.GameEngine
{
    public class BackPack
    {
        private record struct Item(int Id, int value);
        private record struct Slot(int Id, Item item);
        
        public Slot[,] Slots { get; set; }

        public BackPack(Item[,] items)
        {
            for(int i = 0; i < items.Length(0); i++)
            {
                for(int j = 0; j < items.Length(1); j++)
                {
                    slot[i][j].slottedItem = items[i][j];
                }
            }
        }

        public BackPack(int xDimension, int yDimension)
        {
            Slots = new Slot[xDimension][yDimension];
        }

        public void SortByValue()
        {
            int digit = 0;
            item[] itemArray = new int[20];

            //first take all items and put them into a new array to be sorted more easily
            for(int i = 0; i < Slots.Length(0); i++)
            {
               for(j = 0; j < Slots.Length(1); j++)
                {
                   itemArray[i] = Slots[i][j].slottedItem;
                   i++;
                } 
            }

            // this is to find the max value for digit, so we can sort by the digits
            for(int i = 0; i < itemArray.Length; i++)
            {
                int tempDigit = itemArray[i].itemValue%10;
                if(tempDigit > digit)
                {
                    digit = tempDigit;
                }
            }

            // now its time to actually sort through all digits
            for(int g = 1; g <= digit; g++)
            {
                for(i = 1; i < itemArray.Length; i++)
                {
                    int key = itemArray[i]%(10^g);
                    int j = i - 1;
                    while(j > 0 && itemArray[j] % (10^g) < key)
                    {
                        itemArray[j+1] = itemArray[j];
                        j--;
                    }
                    itemArray[j+1] = key;
                }
            }

            //lastly we must put all the sorted items back into the backpack
            for(int i = 0; i < Slots.Length(0); i++)
            {
               for(j = 0; j < Slots.Length(1); j++)
                {
                   Slots[i][j].slottedItem = itemArray[i];
                   i++;
                } 
            }
        }
    }
}