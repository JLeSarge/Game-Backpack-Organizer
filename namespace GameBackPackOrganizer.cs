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

    public class SortByValue
    {
        public static void SortByValue(BackPack input)
        {
            int i = 0;
            int digit = 0;
            item[] itemArray = new int[20];
            //first take all items and put them into a new array to be sorted more easily
            for(i=0;i<input.slot.Length(0);i++)
            {
               for(j=0;j<input.slot.Length(1);j++)
                {
                   itemArray[i] = input.slot[i][j].slottedItem;
                   i++;
                } 
            }
            // this is to find the max value for digit, so we can sort by the digits
            for(i = 0;i<itemArray.Length;i++)
            {
                int tempDigit = itemArray[i].itemValue%10;
                if(tempDigit>digit)
                {
                    digit = tempDigit;
                }
            }
            // now its time to actually sort through all digits
            for(int g=1;g<=digit;g++)
            {
                for(i=1;i<itemArray.Length;i++)
                {
                    int key = itemArray[i]%(10^g);
                    int j = i-1;
                    while(j>0 && itemArray[j]%(10^g)<key)
                    {
                        itemArray[j+1] = itemArray[j];
                        j--;
                    }
                    itemArray[j+1]=key;
                }
            }
            //lastly we must put all the sorted items back into the backpack
            for(i=0;i<input.slot.Length(0);i++)
            {
               for(j=0;j<input.slot.Length(1);j++)
                {
                   input.slot[i][j].slottedItem = itemArray[i];
                   i++;
                } 
            }
            return(input);
        }
    }
}