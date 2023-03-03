using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Objects
{
    public class Item : BaseObject
    {
        public string ItemId { get; set; }
        public string ToType { get; set; }
        public KeyValuePair<int,int>[][] Place { get; set; }
        public Enum GeneralType { get; set; }
        public int Speed { get; set; }
        public string TwoHands { get; set; }
        public KeyValuePair<int, int>[] Attack { get; set; }
        public bool Visual { get; set; } 
        public int Range { get; set; }
        public int Weight { get; set; }
        public int Count { get; set; }

        private static int CurentId = 0;

        public Item()
        {
            CurentId++;
            ItemId = CurentId.ToString();
        }

    }
    

    public class PistolObject : Item
    {
        public PistolObject() : base()
        {
            BackgroundImage = "url(/im/pistol.png)";
            Width = 40;
            Height = 25;
            BackgroundSize = "cover";
            Position = "absolute";
            Left = 0;
            Bottom = 0;
            Type = "guns";
            ToType = "pistol";
            ZIndex = 10;
            Speed = 20;
            Weight = 5;
            Range = 700;
            Visual = true;
        }
    }
    public class AkObject : Item
    {
        public AkObject() : base()
        {
            BackgroundImage = "url(/im/ak.png)";
            Width = 70;
            Height = 25;
            BackgroundSize = "cover";
            Position = "absolute";
            Left = 0;
            Bottom = 0;
            Type = "guns";
            ToType = "ak";
            ZIndex = 10;
            Speed = 40;
            Weight = 20;
            Range = 700;
        }
    }
    public class RifleObject : Item
    {
        public RifleObject() : base()
        {
            BackgroundImage = "url(/im/rifle.png)";
            Width = 70;
            Height = 25;
            BackgroundSize = "cover";
            Position = "absolute";
            Left = 350;
            Bottom = 250;
            Type = "guns";
            ToType = "rifle";
            ZIndex = 10;
            Speed = 5;
            Weight = 20;
            Range = 1400;
            Visual = false;
        }
    }
    public class MinigunObject : Item
    {
        public MinigunObject() : base()
        {
            BackgroundImage = "url(/im/minigun.png)";
            Width = 70;
            Height = 25;
            BackgroundSize = "cover";
            Position = "absolute";
            Left = 350;
            Bottom = 250;
            Type = "guns";
            ToType = "minigun";
            ZIndex = 10;
            Speed = 100;
            Weight = 50;
            Range = 700;
        }
    }
    public class ArmorObject : Item
    {
        public ArmorObject() : base()
        {
            BackgroundImage = "url(/im/armor.png)";
            Width = 50;
            Height = 50;
            BackgroundSize = "cover";
            Position = "absolute";
            Left = 0;
            Bottom = 0;
            Type = "armor";
            ToType = "armor";
            ZIndex = 10;
            AP = 100;
        }
    }
}
