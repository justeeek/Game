using System;
using System.Collections.Generic;

namespace Entity.Objects
{
    public class BaseObject : ICloneable
    {
        public string Id { get; set; }
        public int? UserId { get; set; }
        public int? BulletId { get; set; }
        public double Left { get; set; }
        public double Bottom { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Transform { get; set; }
        public string BackgroundImage { get; set; }
        public string Position { get; set; }
        public string BackgroundSize { get; set; }
        public bool IsMoveble { get; set; }
        public double ZIndex { get; set; }
        public double HP { get; set; }
        public double AP { get; set; }
        public int Curent { get; set; }
        public int Cd { get; set; }
        public string Type { get; set; }

        public int Damage { get; set; }
        public double XDelta { get; set; }
        public double YDelta { get; set; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double Angle { get; set; }
        public List<Item> Items { get; set; }
        public string Team { get; set; }



        private static int CurentId = 0;

        public BaseObject()
        {
            CurentId++;
            Id = CurentId.ToString();
        }

        public object Clone()
        {
            var clone = new BaseObject();
            clone.Id = this.Id;
            clone.Left = this.Left;
            clone.Bottom = this.Bottom;
            clone.Height = this.Height;
            clone.Width = this.Width;
            clone.Transform = this.Transform;
            clone.BackgroundImage = this.BackgroundImage;
            clone.Position = this.Position;
            clone.BackgroundSize = this.BackgroundSize;
            clone.IsMoveble = this.IsMoveble;
            clone.ZIndex = this.ZIndex;
            clone.HP = this.HP;
            clone.Curent = this.Curent;
            clone.Cd = this.Cd;
            clone.Type = this.Type;

            
            clone.XDelta = this.XDelta;
            clone.YDelta = this.YDelta;
            clone.XPos = this.XPos;
            clone.YPos = this.YPos;
            clone.Angle = this.Angle;
            clone.Items = this.Items;
            clone.Team = this.Team;
            clone.UserId = this.UserId;
            
            
            return clone;
        }
    }
}