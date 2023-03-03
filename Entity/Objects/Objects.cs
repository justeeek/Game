using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Objects
{

	public class TableObjects : BaseObject
	{
		public TableObjects() : base()
		{

			BackgroundImage = "url(/im/table.png)";
			Width = 20;
			Height = 20;
			Position = "absolute";
			BackgroundSize = "cover";
			Left = 0;
			Bottom = 0;
			Type = "table";
			ZIndex = 5;
		}
	}
	public class Pol1Objects : BaseObject
	{
		public Pol1Objects() : base()
		{
			
			BackgroundImage =  "url(/im/pol1.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 560;
			Bottom = 505;
			Type = "Pol";
			ZIndex = 1;
		}
	}

	public class Pol2Objects : BaseObject
	{
		public Pol2Objects() : base()
		{

			BackgroundImage = "url(/im/pol2.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 0;
			Bottom = 0;
			Type = "Pol";
			ZIndex = 0;
		}
	}

	public class Pol3Objects : BaseObject
	{
		public Pol3Objects() : base()
		{

			BackgroundImage = "url(/im/pol3.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 0;
			Bottom = 0;
			Type = "Pol";
			ZIndex = 2;
		}
	}

	public class Pol4Objects : BaseObject
	{
		public Pol4Objects() : base()
		{

			BackgroundImage = "url(/im/pol4.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 0;
			Bottom = 0;
			Type = "Pol";
			ZIndex = 3;
		}
	}

	public class Pol5Objects : BaseObject
	{
		public Pol5Objects() : base()
		{

			BackgroundImage = "url(/im/pol5.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 0;
			Bottom = 0;
			Type = "Pol";
			ZIndex = 2;
		}
	}

	public class Pol6Objects : BaseObject
	{
		public Pol6Objects() : base()
		{

			BackgroundImage = "url(/im/pol6.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 0;
			Bottom = 0;
			Type = "Pol";
			ZIndex = 3;
		}
	}

	public class Pol7Objects : BaseObject
	{
		public Pol7Objects() : base()
		{

			BackgroundImage = "url(/im/pol7.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 0;
			Bottom = 0;
			Type = "Pol";
			ZIndex = 3;
		}
	}

	public class Pol8Objects : BaseObject
	{
		public Pol8Objects() : base()
		{

			BackgroundImage = "url(/im/pol8.png)";
			Width = 300;
			Height = 375;
			Position = "absolute";
			Left = 0;
			Bottom = 0;
			Type = "Pol";
			ZIndex = 2;
		}
	}

	public class WallObjects : BaseObject
	{
		public WallObjects() : base()
		{
			Width = 20;
			Height = 20;
			Left = 325;
			Bottom = 883;
			BackgroundImage = "url(/im/Wall.png)";
			BackgroundSize = "cover";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 7;
		}
	}

	public class EnemyObjects : BaseObject
	{
		public EnemyObjects() : base()
		{
			Width = 38;
			Height = 54;
			Left = 350;
			Bottom = 250;
			BackgroundImage = "url(/im/perss.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			Type = "enemy";
			HP = 100;
			IsMoveble = false;
			ZIndex = 6;
		}
	}
	public class DivanObjects : BaseObject
	{
		public DivanObjects() : base()
		{
			Width = 52;
			Height = 143;
			Left = 240;
			Bottom = 85;
			BackgroundImage = "url(/im/divan.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			Transform = " ";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class StolObjects : BaseObject
	{
		public StolObjects() : base()
		{
			Width = 59;
			Height = 95;
			Left = 350;
			Bottom = 100;
			BackgroundImage = "url(/im/stol.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class Stol2Objects : BaseObject
	{
		public Stol2Objects() : base()
		{
			Width = 49;
			Height = 109;
			Left = 791;
			Bottom = 150;
			BackgroundImage = "url(/im/stol2.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class CvetokObjects : BaseObject
	{
		public CvetokObjects() : base()
		{
			Width = 91;
			Height = 84;
			Left = 749;
			Bottom = 420;
			BackgroundImage = "url(/im/cvetok1.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class KitchenObjects : BaseObject
	{
		public KitchenObjects() : base()
		{
			Width = 53;
			Height = 191;
			Left = 1387;
			Bottom = 160;
			BackgroundImage = "url(/im/kitchen.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class StulObjects : BaseObject
	{
		public StulObjects() : base()
		{
			Width = 34;
			Height = 38;
			Left = 1212;
			Bottom = 348;
			BackgroundImage = "url(/im/stul.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class LabaObjects : BaseObject
	{
		public LabaObjects() : base()
		{
			Width = 320;
			Height = 74;
			Left = 1080;
			Bottom = 808;
			BackgroundImage = "url(/im/laba.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class VannaObjects : BaseObject
	{
		public VannaObjects() : base()
		{
			Width = 160;
			Height = 54;
			Left = 330;
			Bottom = 825;
			BackgroundImage = "url(/im/Vanna.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class TualetObjects : BaseObject
	{
		public TualetObjects() : base()
		{
			Width = 42;
			Height = 29;
			Left = 498;
			Bottom = 700;
			BackgroundImage = "url(/im/tualet.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class RakovinaObjects : BaseObject
	{
		public RakovinaObjects() : base()
		{
			Width = 27;
			Height = 30;
			Left = 513;
			Bottom = 600;
			BackgroundImage = "url(/im/rakovina.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class KorobkaObjects : BaseObject
	{
		public KorobkaObjects() : base()
		{
			Width = 82;
			Height = 121;
			Left = 758;
			Bottom = 525;
			BackgroundImage = "url(/im/korobka.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}

	public class Stol3Objects : BaseObject
	{
		public Stol3Objects() : base()
		{
			Width = 208;
			Height = 59;
			Left = 555;
			Bottom = 816;
			BackgroundImage = "url(/im/stol3.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			IsMoveble = false;
			ZIndex = 6;
		}
	}
}
