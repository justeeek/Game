/*using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Objects
{
    public class DynamicObject : BaseObject, ICloneable
    {
        public double XDelta { get; set; }
        public double YDelta { get; set; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double Angle { get; set; }

        public DynamicObject() : base()
        {
        }
        public object Clone()
        {
            var clone = new DynamicObject();
            clone.XDelta = this.XDelta;
            clone.YDelta = this.YDelta;
            clone.XPos = this.XPos;
            clone.YPos = this.YPos;
            clone.Angle = this.Angle;
            return clone;
        }
    }
}*/