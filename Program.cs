using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Driver
{
    public static void Main()
    {
        List<Item> Items = new List<Item>();
        Items.Add(new Item());
        Items[0].name = "Laptop";
        Items[0].price = 499.99;
        Items[0].quantity = 200;

        Items.Add(new Item());
        Items[1].name = "Tablet";
        Items[1].price = 374.99;
        Items[1].quantity = 150;

        Items.Add(new Item());
        Items[2].name = "Hard Drive";
        Items[2].price = 199.99;
        Items[2].quantity = 75;

        Items.Add(new Item());
        Items[3].name = "Cell Phone";
        Items[3].price = 999.99;
        Items[3].quantity = 275;

        Items.Add(new Item());
        Items[4].name = "Wireless Headphones";
        Items[4].price = 284.99;
        Items[4].quantity = 120;

        Items.Add(new Item());
        Items[5].name = "Monitor";
        Items[5].price = 699.99;
        Items[5].quantity = 110;

        Items.Add(new Item());
        Items[6].name = "Wireless Mouse";
        Items[6].price = 189.99;
        Items[6].quantity = 350;

        Items.Add(new Item());
        Items[7].name = "Computer Desk";
        Items[7].price = 1199.99;
        Items[7].quantity = 10;

        Items.Add(new Item());
        Items[8].name = "Computer hair";
        Items[8].price = 409.99;
        Items[8].quantity = 15;


        InventoryManager im = new InventoryManager();
        im.addItem(Items[0]);
        im.addItem(Items[1]);
        im.addItem(Items[2]);
        im.addItem(Items[3]);
        im.addItem(Items[4]);
        im.addItem(Items[5]);
        im.addItem(Items[6]);
        im.addItem(Items[7]);
        im.addItem(Items[8]);


        im.displayItems();


        Console.WriteLine("\nFound Item:");
        im.searchByPrice(174.99);

    }


    class InventoryManager
    {
        private Item[] inventory;
        private int count;

        public InventoryManager()
        {
            this.inventory = new Item[50];
            this.count = 0;
        }

        public void addItem(Item newItem)
        {
            if (this.count < 50)
            {
                this.inventory[this.count] = newItem;
                this.count += 1;
            }
        }

        public void removeItem(int indexToDelete)
        {
            if (indexToDelete < this.count)
            {
                this.inventory = this.inventory.Where((source, index) => index != indexToDelete).ToArray();
                this.count -= 1;
            }
        }

        public void reStock(Item item, int quantity)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.inventory[i].name.Equals(item.name))
                {
                    this.inventory[i].quantity = quantity;
                }
            }
        }

        public void displayItems()
        {
            for (int i = 0; i < this.count; i++)
            {
                Console.WriteLine(this.inventory[i]);
            }
        }

        public void searchByName(string itemName)
        {
            Item? found = null;

            for (int i = 0; i < this.count; i++)
            {
                if (this.inventory[i].name.Equals(itemName))
                {
                    found = this.inventory[i];
                    break;
                }
            }

            if (found != null)
            {
                Console.WriteLine(found);
            }
            else
            {
                Console.WriteLine("No Item Found!");
            }
        }







        public void searchByPrice(double itemPrice)
        {
            Item found = null;

            for (int i = 0; i < this.count; i++)
            {
                if (this.inventory[i].price == itemPrice)
                {
                    found = this.inventory[i];
                    break;
                }
            }

            if (found != null)
            {
                Console.WriteLine(found);
            }
            else
            {
                Console.WriteLine("No Item Found!");
            }
        }


    }

    class Item
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

        public Item()
        {
            this.name = "";
            this.price = 0.0;
            this.quantity = 0;
        }

        public Item(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return this.name + " " + this.price + " " + this.quantity;
        }
    }
}
