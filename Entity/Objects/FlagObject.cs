using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Objects
{
	public class BlueFlag : BaseObject
	{
		public BlueFlag() : base()
		{

			BackgroundImage = "url(/im/BlueFlag.png)";
			Width = 35;
			Height = 90;
			Position = "absolute";
			BackgroundSize = "cover";
			Left = 0;
			Bottom = 0;
			Type = "blueflag";
			ZIndex = 7;
		}
	}

	public class RedFlag : BaseObject
	{
		public RedFlag() : base()
		{

			BackgroundImage = "url(/im/RedFlag.png)";
			Width = 35;
			Height = 90;
			Position = "absolute";
			BackgroundSize = "cover";
			Left = 0;
			Bottom = 0;
			Type = "redflag";
			ZIndex = 7;
		}
	}
}
