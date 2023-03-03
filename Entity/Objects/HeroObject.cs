using System;
using System.Collections.Generic;

namespace Entity.Objects
{
	public class HeroObject : BaseObject
	{
		

		public HeroObject() : base()
        {
			Width = 60;
			Height = 40;
			Left = 910;
			Bottom = 150;
			BackgroundImage = "url(/im/skin1.png)";
			BackgroundSize = "cover";
			Position = "absolute";
			Type = "hero";
			ZIndex = 100;
			Angle = 0;
			HP = 100;
			AP = 100;
			IsMoveble = true;
			//UserId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;
			Items = new List<Item>(){};
			Team = "blue";
			
        }
    }
	
	public class Hero2Object : BaseObject
	{
		

		public Hero2Object() : base()
		{
			Width = 60;
			Height = 40;
			Left = 910;
			Bottom = 150;
			BackgroundImage = "url(/im/skin2.png)";
			BackgroundSize = "cover";
			Position = "absolute";
			Type = "hero";
			ZIndex = 10;
			Angle = 0;
			HP = 100;
			IsMoveble = true;
			//UserId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;

		}
	}
	public class Hero3Object : BaseObject
	{
		

		public Hero3Object() : base()
		{
			Width = 60;
			Height = 40;
			Left = 910;
			Bottom = 150;
			BackgroundImage = "url(/im/skin3.png)";
			BackgroundSize = "cover";
			Position = "absolute";
			Type = "hero";
			ZIndex = 10;
			Angle = 0;
			HP = 100;
			IsMoveble = true;
			//UserId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;

		}
	}
	public class Hero4Object : BaseObject
	{
		

		public Hero4Object() : base()
		{
			Width = 60;
			Height = 40;
			Left = 910;
			Bottom = 150;
			BackgroundImage = "url(/im/skin4.png)";
			BackgroundSize = "cover";
			Position = "absolute";
			Type = "hero";
			ZIndex = 10;
			Angle = 0;
			HP = 100;
			IsMoveble = true;
			//UserId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;

		}
	}
	public class DeadHero : BaseObject
	{
		
		public DeadHero() : base()
		{
			Width = 60;
			Height = 40;
			Left = 0;
			Bottom = 0;
			BackgroundImage = "url(/im/dead.png)";
			BackgroundSize = "cover";
			Position = "absolute";
			Type = "deadhero";
			ZIndex = 10;
			//Angle = 0;
			//HP = 100;
			IsMoveble = false;
			//UserId = 0;
			//XDelta = 0;
			//YDelta = 0;
			//XPos = 0;
			//YPos = 0;

		}
	}
}