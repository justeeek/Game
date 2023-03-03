using System;
using System.Collections.Generic;

namespace Entity.Objects
{
	public class MinigunBullet : BaseObject
	{
		

		public MinigunBullet() : base()
		{
			Width = 15;
			Height = 15;
			BackgroundImage = "url(/im/MinigunBullet.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			Type = "bullet";
			IsMoveble = true;
			Curent = 0;
			//BulletId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;
			Cd = 0;
			ZIndex = 9;
			Damage = 20;
		}
	}
	public class PistolBullet : BaseObject
	{
		

		public PistolBullet() : base()
		{
			Width = 15;
			Height = 10;
			BackgroundImage = "url(/im/PistolBullet.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			Type = "bullet";
			IsMoveble = true;
			Curent = 0;
			//BulletId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;
			Cd = 0;
			ZIndex = 9;
			Damage = 10;
		}
	}
	public class AkBullet : BaseObject
	{
		

		public AkBullet() : base()
		{
			Width = 20;
			Height = 15;
			BackgroundImage = "url(/im/AkBullet.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			Type = "bullet";
			IsMoveble = true;
			Curent = 0;
			//BulletId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;
			Cd = 0;
			ZIndex = 9;
			Damage = 25;
		}
	}
	public class RifleBullet : BaseObject
	{
		

		public RifleBullet() : base()
		{
			Width = 22;
			Height = 10;
			BackgroundImage = "url(/im/RifleBullet.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			Type = "bullet";
			IsMoveble = true;
			Curent = 0;
			//BulletId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;
			Cd = 0;
			ZIndex = 9;
			Damage = 100;
		}
	}

	public class SurikenBullet : BaseObject
	{
		

		public SurikenBullet() : base()
		{
			Width = 20;
			Height = 20;
			BackgroundImage = "url(/im/Suriken.png)";
			BackgroundSize = "contain";
			Position = "absolute";
			Type = "bullet";
			IsMoveble = true;
			Curent = 0;
			//BulletId = 0;
			XDelta = 0;
			YDelta = 0;
			XPos = 0;
			YPos = 0;
			Cd = 0;
			ZIndex = 9;
			Damage = 10;
		}
	}

}