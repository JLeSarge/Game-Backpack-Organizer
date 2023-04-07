namespace GameBackPackOrganizer.GameEngine
{
    public class BackPack
    {
        public BackPackSlot[5][4] slot{get; set;}

        public Item nothing = new Item(-1,0);
        public BackPack()
        {
            //create an empty backpack
            int id = 0;
   
             for(int i=0;i<BackPackSlot.Length(1);i++)
            {
                for(int j=0;j<BackPackSlot.Length(0);j++)
                {
                    BackPackSlot[i][j] = new BackPackSlot(id,nothing,0);
                    id += 10;
                }
                id++;
            }
        }
        // fill in backpack with an already created backpackslot matrix
        public BackPack(BackPackSlot[][] items)
        {
            for(int i=0;i<items.Length(1);i++)
            {
                for(int j=0;j<items.Length(0);j++)
                {
                    if(items[i][j].slottedItem.itemValue>0)
                    {
                        BackPackSlot[i][j] = new BackPackSlot(items[i][j].slotID,items[i][j].slottedItem,items[i][j].itemAmount);
                    }
                    else
                    {
                        BackPackSlot[i][j] = new BackPackSlot(items[i][j].slotID,nothing,0);
                    }
                    
                }
            }
            
        }
        public AddItem(int slotId,Item item,int amount)
        {
            slot[slotId/10][slotId%10].slottedItem = item;
            slot[slotId/10][slotId%10].itemAmount = amount;
        }
         public static void SortByValue(BackPack input)
        {
            int i = 0;
            int digit = 0;
            BackPackSlot[] slotArray = new int[20];
            //first take all items and put them into a new array to be sorted more easily
            for(i=0;i<input.slot.Length(0);i++)
            {
               for(j=0;j<input.slot.Length(1);j++)
                {
                   slotArray[i] = input.slot[i][j];
                   i++;
                } 
            }
            // this is to find the max value for digit, so we can sort by the digits
            for(i = 0;i<slotArray.Length;i++)
            {
                int tempDigit = (slotArray[i].slottedItem.itemValue*slotArray[i].itemAmount)/10;
                if(tempDigit>digit)
                {
                    digit = tempDigit;
                }
            }
            // now its time to actually sort through all digits
            for(int g=1;g<=digit;g++)
            {
                for(i=1;i<slotArray.Length;i++)
                {
                    int key = (slotArray[i].slottedItem.itemValue * slotArray[i].itemAmount) / (10^g);
                    int j = i-1;
                    while(j>0 && (slotArray[j].slottedItem.itemValue * slotArray[j].itemAmount) / (10^g)<key)
                    {
                        slotArray[j+1] = slotArray[j];
                        j--;
                    }
                    slotArray[j+1]=key;
                }
            }
            //lastly we must put all the sorted items back into the backpack
            for(i=0;i<input.slot.Length(1);i++)
            {
               for(j=0;j<input.slot.Length(0);j++)
                {
                   input.slot[i][j] = slotArray[i];
                   i++;
                } 
            }
            return(input);
        }
    }

    public class BackPackSlot
    {
        public int slotID{get; set;}
        public item slottedItem{get; set;}
        public int itemAmount {get; set;}

        public int slotValue {get; set;}

        public BackPackSlot(int id,Item item, int amount)
        {
            slotID = id;
            slottedItem = item;
            itemAmount = amount;
            slotValue = item.itemValue * amount;
        }
        
    }

    public class Item 
    {
        public int itemID{get; set;}
        public int itemValue{get; set;}
        
        public item(int ID, int itemVal)
        {
            itemID = ID;
            itemValue = itemval;
        }
    }

       
}