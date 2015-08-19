
namespace PhoneComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MobilePhone
    {
        public static MobilePhone iPhone4S = new MobilePhone
            ("4S", "Iphone", 485, "Bai Ivan",
            new Battery(132321, 200, 14, Battery.BatteryType.LiIon),
            new Display("TFT", 3.5, 16)
            );
        private readonly List<Calls> callHistory;
        private const double PricePerMinute = 0.37;

        private string model;
        private string manufacturer;
        private int price;
        private string owner;
        private Display displayOfPhone;
        private Battery batteryOfPhone;


        public MobilePhone(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = int.MinValue;
            this.Owner = null;
            this.displayOfPhone = null;
            this.batteryOfPhone = null;

        }

        public MobilePhone(string model, string manufacturer, int price, string owner, Battery battryOfPhone, Display displayOfPhone)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.displayOfPhone = displayOfPhone;
            this.batteryOfPhone = battryOfPhone;
            this.callHistory = new List<Calls>();
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (value != "" || value != null)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("You must type a phone model");
                }
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (value != "" || value != null)
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("You must choose a manufacturer");
                }
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }
        public List<Calls> CallHistory
        {
            get
            {
                return new List<Calls>(this.callHistory);
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                this.owner = value;
            }
        }

        public void AddCall(Calls call)
        {
            this.callHistory.Add(call);
        }

        public void RemoveCall(Calls call)
        {
            int index = callHistory.IndexOf(call);

            this.callHistory.RemoveAt(index);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public double PriceOfCall()
        {
            long talkTime = 0;

            foreach (var time in this.CallHistory)
            {
                talkTime += time.CallDuration;
            }

            double totalPrice = (double)(talkTime / 60) * PricePerMinute;
            return totalPrice;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Information about phone: ");
            result.AppendLine("Model: " + this.model);
            result.AppendLine("Manufacturer: " + this.manufacturer);
            result.AppendLine("Price: " + this.price.ToString());
            result.AppendLine("Owner: " + this.owner);
            result.AppendLine("Battery: " + this.batteryOfPhone);
            result.AppendLine("Display: " + this.displayOfPhone);
            return result.ToString();
        }
    }

    public class Display
    {
        private string displayType;
        private double size;
        private int colors;

        public Display(string displayType, double size, int colors)
        {
            this.displayType = displayType;
            this.size = size;
            this.colors = colors;
        }
        public string DisplayType
        {
            get
            {
                return this.displayType;
            }
            private set
            {
                this.displayType = value;
            }
        }
        public double Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException();
                }
                this.size = value;
            }
        }
        public int Colors
        {
            get
            {
                return this.colors;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                this.colors = value;
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Display type: " + this.DisplayType);
            result.AppendLine("Size: " + this.Size + " inches.");
            result.AppendLine("Colors: " + this.Colors + "M");
            return result.ToString();
        }
    }

    public class Battery
    {
        private int modelOfBattery;
        private int iDLETime;
        private int talkTime;
        private BatteryType typeOfBattery;

        public Battery(int modelOfBattery, int iDLETime, int talkTime, BatteryType typeOfBattery)
        {
            this.modelOfBattery = modelOfBattery;
            this.iDLETime = iDLETime;
            this.talkTime = talkTime;
        }
        public int ModelOfBattery
        {
            get
            {
                return this.modelOfBattery;
            }
            private set
            {
                this.modelOfBattery = value;
            }
        }
        public int IDLETime
        {
            get
            {
                return this.iDLETime;
            }
            private set
            {
                this.iDLETime = value;
            }
        }
        public int TalkTime
        {
            get
            {
                return this.talkTime;
            }
            private set
            {
                this.talkTime = value;
            }
        }

        public BatteryType TypeOFBattery
        {
            get
            {
                return this.typeOfBattery;
            }
            private set
            {
                this.typeOfBattery = value;
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Model of battery: " + this.ModelOfBattery);
            result.AppendLine("IDLE time: " + this.IDLETime + "hours.");
            result.AppendLine("Talk time: " + this.TalkTime + "hours.");
            result.AppendLine("Battery type: " + this.TypeOFBattery);
            return result.ToString();
        }
        public Battery(BatteryType typeOfBattery)
        {
            this.typeOfBattery = typeOfBattery;
        }

        public enum BatteryType
        {
            LiIon,
            LiPol,
            NiMH,
            NiCd
        }
    }


    public class MobilePhoneAndCallsTest
    {
        static Random randomPick = new Random();
        static string[] brand = new[] { "HTC", "LG", "Samsung", "Motorola", "Nokia", "Sony" };
        static string[] model = new[] { "X", "G", "E", "5S", "4S", "Marmalad", "3310", "G3" };
        static int[] price = new[] { 150, 1000, 232, 600, 900, 1300 };
        static string[] owner = new[] { "Ivan", "Gosho", "Mariq", "Pesho", "Silviq", "Diana" };

        static Battery[] batteries = new[]
        { 
            new Battery(842343,300, 11, Battery.BatteryType.NiCd),
            new Battery(1234345, 420, 19, Battery.BatteryType.LiPol),
            new Battery(123415, 230, 10, Battery.BatteryType.LiIon)
        };

        static Display[] displays = new[]
        {
            new Display("LCD", 4.7, 16),
            new Display("AMOLED", 5.2, 16 ),
            new Display("TFT", 4.0, 1)
        };

        static void Main()
        {
            MobilePhone[] testPhones = new MobilePhone[3];

            for (int i = 0; i < 3; i++)
            {
                testPhones[i] = new MobilePhone(
                    model[randomPick.Next(0, model.Length)],
                    brand[randomPick.Next(0, brand.Length)],
                    price[randomPick.Next(0, price.Length)],
                    owner[randomPick.Next(0, owner.Length)],
                    batteries[randomPick.Next(0, batteries.Length)],
                    displays[randomPick.Next(0, displays.Length)]);
                Console.WriteLine(testPhones[i]);
            }

            var testIphone4S = MobilePhone.iPhone4S;
            Console.WriteLine(testIphone4S);

            MobilePhone testPhone = MobilePhone.iPhone4S;

            testPhone.AddCall(new Calls("882131411", randomPick.Next(1, 1000)));
            testPhone.AddCall(new Calls("877717222", randomPick.Next(1, 1000)));
            testPhone.AddCall(new Calls("886687341", randomPick.Next(1, 1000)));
            testPhone.AddCall(new Calls("894141411", randomPick.Next(1, 1000)));
            testPhone.AddCall(new Calls("893783343", randomPick.Next(1, 1000)));

            foreach (var call in testPhone.CallHistory)
            {
                Console.WriteLine(call.ToString());
            }

            Console.WriteLine("The total cost of all conversations is {0:C}\n", testPhone.PriceOfCall());
            Calls longest = testPhone.CallHistory.OrderByDescending(x => x.CallDuration).FirstOrDefault(); 
            testPhone.RemoveCall(longest);
            Console.WriteLine("The total cost after remove longest conversation is: {0:C}\n"
                , testPhone.PriceOfCall());

            testPhone.ClearCallHistory();
            Console.WriteLine("Total number of Calls in Call History {0}\n", testPhone.CallHistory.Count);
        }
    }

    public class Calls
    {
        private const string PhoneCode = "+359";

        private DateTime dateTime;
        private string phoneNumber;
        private int callDuration;

        public Calls(string phoneNumber, int callDuration)
        {
            this.dateTime = DateTime.Now;
            this.PhoneNumber = PhoneCode + phoneNumber;
            this.CallDuration = callDuration;
        }

        public DateTime DateTime { get; private set; }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value.Length < 4 || value.Length > 13)
                {
                    throw new ArgumentOutOfRangeException("The Phone number length should be between 4 and 9 digits");
                }
                this.phoneNumber = value;
            }
        }

        public int CallDuration
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Call must be longer than 1 second!");
                }
                this.callDuration = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Information about the Call:");
            result.AppendFormat("On {0:d} call to {1} for {2} sec.", dateTime, PhoneNumber, callDuration);
            return result.ToString();
        }
    }
}
