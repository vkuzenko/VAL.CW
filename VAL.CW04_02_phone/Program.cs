using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAL.CW04_02_phone
{
    public class Shop {
        public string Name { get; set; }
        public string Address { get; set; }
        public Warehouse[] Warehouses { get; set; }

        public Shop(string name, string address, int warehouseCnt)
        {
            this.Name = name;
            this.Address = address;
            this.Warehouses = new Warehouse[warehouseCnt];
            InitWarehouses();
        }

        private void InitWarehouses()
        {
            for (int i = 0; i < this.Warehouses.Length; i++)
            {
                Warehouses[i] = new Warehouse("Polevaya " + i, i + 1);
            }
        }

        public void ReceivePhones(Phone[] phones)
        {
            int i = 0;
            if (phones == null || phones.Length == 0)
            {
                Console.WriteLine("Can't receive phones, a list is empty.");
                return;
            }
            foreach (var warehouse in this.Warehouses)
            {
                if (!warehouse.IsFull)
                {
                    warehouse.AddPhone(phones[i]);
                    i++;
                    if (i == phones.Length)
                    {
                        return;
                    }
                }
            }
        }

        public void ShowPhones()
        {
            int i;
            int j;

            i = 1;
            foreach (var warehouse in this.Warehouses)
            {
                Console.WriteLine(i + " " + warehouse.Address);
                i++;
                j = 1;
                foreach (var phone in warehouse.Phones)
                {
                    if (phone != null)
                    {
                        Console.WriteLine("  " + j + " " + phone.Model + ", " + phone.Price);
                    }
                    else
                    {
                        Console.WriteLine("  " + j + " - ");
                    }
                    j++;
                }
            }
            Console.WriteLine();
        }

    }

    public class Warehouse {
        public string Address { get; set; }
        public Phone[] Phones { get; set; }
        public bool IsFull
        {
            get
            {
                foreach (var phone in Phones)
                {
                    if (phone == null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public Warehouse(string address, int phonesCnt)
        {
            this.Address = address;
            this.Phones = new Phone[phonesCnt];
        }

        public void AddPhone(Phone phone)
        {
            for (int i = 0; i < this.Phones.Length; i++)
            {
                if (Phones[i] == null)
                {
                    Phones[i] = phone;
                    break;
                }
            }
        }
    }

    public class Phone
    {
        public string Model { get; set; }
        public string ProduceedBy { get; set; }
        public int Price { get; set; }
        public DateTime ProducedAt { get; set; }

        public Phone(string model, int price)
        {
            this.Model = model;
            this.Price = price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shop Shop01 = new Shop("MyShop", "Kiev", 5);

            Phone[] NewPhones = new Phone[] {
                new Phone("Nokia", 10),
                new Phone("Samsung", 20),
                new Phone("Apple", 30)
            };

            //Shop01.ShowPhones();
            Shop01.ReceivePhones(NewPhones);
            Shop01.ReceivePhones(NewPhones);
            Shop01.ShowPhones();

            Console.ReadLine();

        }
    }
}
