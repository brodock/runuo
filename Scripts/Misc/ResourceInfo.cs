using System;
using System.Collections;

namespace Server.Items
{
	public enum CraftResource
	{
		None = 0,
		Iron = 1,
		DullCopper,
		ShadowIron,
		Copper,
		Bronze,
		Gold,
		Agapite,
		Verite,
		Valorite,

		RegularLeather = 101,
		SpinedLeather,
		HornedLeather,
		BarbedLeather,

		RedScales = 201,
		YellowScales,
		BlackScales,
		GreenScales,
		WhiteScales,
		BlueScales,

		RegularWood = 301,
		OakWood,
		AshWood,
		YewWood,
		Heartwood,
		Bloodwood,
		Frostwood
	}

	public enum CraftResourceType
	{
		None,
		Metal,
		Leather,
		Scales,
		Wood
	}

	public class CraftAttributeInfo
	{
		private BonusAttribute[] m_WeaponAttributes;
		private BonusAttribute[] m_ArmorAttributes;
		private BonusAttribute[] m_ShieldAttributes;
		private BonusAttribute[] m_OtherAttributes;
		
		private int m_RandomAttributeCount;
		private BonusAttribute[] m_WeaponRandomAttributes;
		private BonusAttribute[] m_ArmorRandomAttributes;
		private BonusAttribute[] m_ShieldRandomAttributes;
		private BonusAttribute[] m_OtherRandomAttributes;

		private int m_RunicMinAttributes;
		private int m_RunicMaxAttributes;
		private int m_RunicMinIntensity;
		private int m_RunicMaxIntensity;
		
		public BonusAttribute[] WeaponAttributes{ get{ return m_WeaponAttributes; } set{ m_WeaponAttributes = value; } }
		public BonusAttribute[] ArmorAttributes{ get{ return m_ArmorAttributes; } set{ m_ArmorAttributes = value; } }
		public BonusAttribute[] ShieldAttributes{ get{ return m_ShieldAttributes; } set{ m_ShieldAttributes = value; } }
		public BonusAttribute[] OtherAttributes{ get{ return m_OtherAttributes; } set{ m_OtherAttributes = value; } }
		
		public int RandomAttributeCount{ get{ return m_RandomAttributeCount; } set{ m_RandomAttributeCount = value; } }
		public BonusAttribute[] WeaponRandomAttributes{ get{ return m_WeaponRandomAttributes; } set{ m_WeaponRandomAttributes = value; } }
		public BonusAttribute[] ArmorRandomAttributes{ get{ return m_ArmorRandomAttributes; } set{ m_ArmorRandomAttributes = value; } }
		public BonusAttribute[] ShieldRandomAttributes{ get{ return m_ShieldRandomAttributes; } set{ m_ShieldRandomAttributes = value; } }
		public BonusAttribute[] OtherRandomAttributes{ get{ return m_OtherRandomAttributes; } set{ m_OtherRandomAttributes = value; } }

		public int RunicMinAttributes{ get{ return m_RunicMinAttributes; } set{ m_RunicMinAttributes = value; } }
		public int RunicMaxAttributes{ get{ return m_RunicMaxAttributes; } set{ m_RunicMaxAttributes = value; } }
		public int RunicMinIntensity{ get{ return m_RunicMinIntensity; } set{ m_RunicMinIntensity = value; } }
		public int RunicMaxIntensity{ get{ return m_RunicMaxIntensity; } set{ m_RunicMaxIntensity = value; } }

		public CraftAttributeInfo()
		{
		}

		public static readonly CraftAttributeInfo Blank;
		public static readonly CraftAttributeInfo DullCopper, ShadowIron, Copper, Bronze, Golden, Agapite, Verite, Valorite;
		public static readonly CraftAttributeInfo Spined, Horned, Barbed;
		public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales;
		public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;

		static CraftAttributeInfo()
		{
			Blank = new CraftAttributeInfo();

			CraftAttributeInfo dullCopper = DullCopper = new CraftAttributeInfo();

			dullCopper.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 6 ), 
				new BonusAttribute( AosArmorAttribute.DurabilityBonus, 50 ),
				new BonusAttribute( AosArmorAttribute.LowerStatReq, 20 )
			};
			dullCopper.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosWeaponAttribute.DurabilityBonus, 100 ),
				new BonusAttribute( AosWeaponAttribute.LowerStatReq, 50 ) 
			};
			dullCopper.RunicMinAttributes = 1;
			dullCopper.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				dullCopper.RunicMinIntensity = 40;
				dullCopper.RunicMaxIntensity = 100;
			}
			else
			{
				dullCopper.RunicMinIntensity = 10;
				dullCopper.RunicMaxIntensity = 35;
			}

			CraftAttributeInfo shadowIron = ShadowIron = new CraftAttributeInfo();

			shadowIron.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 2 ), 
				new BonusAttribute( ResistanceType.Fire, 1 ),
				new BonusAttribute( ResistanceType.Energy, 5 ),
				new BonusAttribute( AosArmorAttribute.DurabilityBonus, 100 )
			};
			shadowIron.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosElementAttribute.Cold, 20 ),
				new BonusAttribute( AosWeaponAttribute.DurabilityBonus, 50 ) 
			};
			shadowIron.RunicMinAttributes = 2;
			shadowIron.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				shadowIron.RunicMinIntensity = 45;
				shadowIron.RunicMaxIntensity = 100;
			}
			else
			{
				shadowIron.RunicMinIntensity = 20;
				shadowIron.RunicMaxIntensity = 45;
			}

			CraftAttributeInfo copper = Copper = new CraftAttributeInfo();

			copper.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 1 ), 
				new BonusAttribute( ResistanceType.Fire, 1 ),
				new BonusAttribute( ResistanceType.Poison, 5 ),
				new BonusAttribute( ResistanceType.Energy, 2 )
			};
			copper.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosElementAttribute.Poison, 10 ),
				new BonusAttribute( AosElementAttribute.Energy, 20 ) 
			};
			copper.RunicMinAttributes = 2;
			copper.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				copper.RunicMinIntensity = 50;
				copper.RunicMaxIntensity = 100;
			}
			else
			{
				copper.RunicMinIntensity = 25;
				copper.RunicMaxIntensity = 50;
			}

			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

			bronze.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 3 ), 
				new BonusAttribute( ResistanceType.Cold, 5 ),
				new BonusAttribute( ResistanceType.Poison, 1 ),
				new BonusAttribute( ResistanceType.Energy, 1 )
			};
			bronze.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosElementAttribute.Fire, 40 )
			};
			bronze.RunicMinAttributes = 3;
			bronze.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				bronze.RunicMinIntensity = 55;
				bronze.RunicMaxIntensity = 100;
			}
			else
			{
				bronze.RunicMinIntensity = 30;
				bronze.RunicMaxIntensity = 65;
			}

			CraftAttributeInfo golden = Golden = new CraftAttributeInfo();

			golden.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 1 ), 
				new BonusAttribute( ResistanceType.Fire, 1 ),
				new BonusAttribute( ResistanceType.Cold, 2 ),
				new BonusAttribute( ResistanceType.Energy, 2 ),
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosArmorAttribute.LowerStatReq, 30 )
			};
			golden.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosWeaponAttribute.LowerStatReq, 50 )
			};
			golden.RunicMinAttributes = 3;
			golden.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				golden.RunicMinIntensity = 60;
				golden.RunicMaxIntensity = 100;
			}
			else
			{
				golden.RunicMinIntensity = 35;
				golden.RunicMaxIntensity = 75;
			}

			CraftAttributeInfo agapite = Agapite = new CraftAttributeInfo();

			agapite.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 2 ), 
				new BonusAttribute( ResistanceType.Fire, 3 ),
				new BonusAttribute( ResistanceType.Cold, 2 ),
				new BonusAttribute( ResistanceType.Poison, 2 ),
				new BonusAttribute( ResistanceType.Energy, 2 )
			};
			agapite.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosElementAttribute.Cold, 30 ),
				new BonusAttribute( AosElementAttribute.Energy, 20 )
			};
			agapite.RunicMinAttributes = 4;
			agapite.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				agapite.RunicMinIntensity = 65;
				agapite.RunicMaxIntensity = 100;
			}
			else
			{
				agapite.RunicMinIntensity = 40;
				agapite.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo verite = Verite = new CraftAttributeInfo();

			verite.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 3 ), 
				new BonusAttribute( ResistanceType.Fire, 3 ),
				new BonusAttribute( ResistanceType.Cold, 2 ),
				new BonusAttribute( ResistanceType.Poison, 3 ),
				new BonusAttribute( ResistanceType.Energy, 1 )
			};
			verite.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosElementAttribute.Poison, 40 ),
				new BonusAttribute( AosElementAttribute.Energy, 20 )
			};
			verite.RunicMinAttributes = 4;
			verite.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				verite.RunicMinIntensity = 70;
				verite.RunicMaxIntensity = 100;
			}
			else
			{
				verite.RunicMinIntensity = 45;
				verite.RunicMaxIntensity = 90;
			}

			CraftAttributeInfo valorite = Valorite = new CraftAttributeInfo();

			valorite.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 4 ), 
				new BonusAttribute( ResistanceType.Cold, 3 ),
				new BonusAttribute( ResistanceType.Poison, 3 ),
				new BonusAttribute( ResistanceType.Energy, 3 ),
				new BonusAttribute( AosArmorAttribute.DurabilityBonus, 50 )
			};
			valorite.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosElementAttribute.Fire, 10 ),
				new BonusAttribute( AosElementAttribute.Cold, 20 ),
				new BonusAttribute( AosElementAttribute.Poison, 10 ),
				new BonusAttribute( AosElementAttribute.Energy, 20 )
			};
			valorite.RunicMinAttributes = 5;
			valorite.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				valorite.RunicMinIntensity = 85;
				valorite.RunicMaxIntensity = 100;
			}
			else
			{
				valorite.RunicMinIntensity = 50;
				valorite.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo spined = Spined = new CraftAttributeInfo();

			spined.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 5 ), 
				new BonusAttribute( AosAttribute.Luck, 40 )
			};
			spined.RunicMinAttributes = 1;
			spined.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				spined.RunicMinIntensity = 40;
				spined.RunicMaxIntensity = 100;
			}
			else
			{
				spined.RunicMinIntensity = 20;
				spined.RunicMaxIntensity = 40;
			}

			CraftAttributeInfo horned = Horned = new CraftAttributeInfo();

			horned.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 2 ),
				new BonusAttribute( ResistanceType.Fire, 3 ),
				new BonusAttribute( ResistanceType.Cold, 2 ),
				new BonusAttribute( ResistanceType.Poison, 2 ),
				new BonusAttribute( ResistanceType.Energy, 2 )
			};
			horned.RunicMinAttributes = 3;
			horned.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				horned.RunicMinIntensity = 45;
				horned.RunicMaxIntensity = 100;
			}
			else
			{
				horned.RunicMinIntensity = 30;
				horned.RunicMaxIntensity = 70;
			}

			CraftAttributeInfo barbed = Barbed = new CraftAttributeInfo();

			barbed.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 2 ),
				new BonusAttribute( ResistanceType.Fire, 1 ),
				new BonusAttribute( ResistanceType.Cold, 2 ),
				new BonusAttribute( ResistanceType.Poison, 3 ),
				new BonusAttribute( ResistanceType.Energy, 4 )
			};
			barbed.RunicMinAttributes = 4;
			barbed.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				barbed.RunicMinIntensity = 50;
				barbed.RunicMaxIntensity = 100;
			}
			else
			{
				barbed.RunicMinIntensity = 40;
				barbed.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo red = RedScales = new CraftAttributeInfo();

			red.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Fire, 10 ),
				new BonusAttribute( ResistanceType.Cold, -3 )
			};

			CraftAttributeInfo yellow = YellowScales = new CraftAttributeInfo();

			yellow.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, -3 ),
				new BonusAttribute( AosAttribute.Luck, 20 )
			};

			CraftAttributeInfo black = BlackScales = new CraftAttributeInfo();

			black.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 10 ),
				new BonusAttribute( ResistanceType.Energy, -3 )
			};

			CraftAttributeInfo green = GreenScales = new CraftAttributeInfo();

			green.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Fire, -3 ),
				new BonusAttribute( ResistanceType.Poison, 10 )
			};

			CraftAttributeInfo white = WhiteScales = new CraftAttributeInfo();

			white.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, -3 ),
				new BonusAttribute( ResistanceType.Cold, 10 )
			};

			CraftAttributeInfo blue = BlueScales = new CraftAttributeInfo();

			blue.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Poison, -3 ),
				new BonusAttribute( ResistanceType.Energy, 10 )
			};

			#region Mondain's Legacy
			CraftAttributeInfo oak = OakWood = new CraftAttributeInfo();
			
			oak.ArmorAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 3 ),
				new BonusAttribute( ResistanceType.Fire, 3 ),
				new BonusAttribute( ResistanceType.Poison, 2 ),
				new BonusAttribute( ResistanceType.Energy, 3 ),
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosArmorAttribute.DurabilityBonus, 50 )
			};
			oak.WeaponAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosAttribute.WeaponDamage, 5 ),
				new BonusAttribute( AosWeaponAttribute.DurabilityBonus, 50 )
			};
			oak.ShieldAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Physical, 1 ),
				new BonusAttribute( ResistanceType.Fire, 1 ),
				new BonusAttribute( ResistanceType.Cold, 1 ),
				new BonusAttribute( ResistanceType.Poison, 1 ),
				new BonusAttribute( ResistanceType.Energy, 1 )
			};
			oak.OtherAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosAttribute.Luck, 40 ) 
			};
			oak.RunicMinAttributes = 1;
			oak.RunicMaxAttributes = 2;
			oak.RunicMinIntensity = 1;
			oak.RunicMaxIntensity = 50;

			CraftAttributeInfo ash = AshWood = new CraftAttributeInfo();

			ash.ArmorAttributes = new BonusAttribute[] {
				new BonusAttribute( ResistanceType.Physical, 3 ),
				new BonusAttribute( ResistanceType.Cold, 3 ),
				new BonusAttribute( ResistanceType.Poison, 2 ),
				new BonusAttribute( ResistanceType.Energy, 3 ),
				new BonusAttribute( AosArmorAttribute.LowerStatReq, 20 ),
				new BonusAttribute( AosAttribute.LowerWeight, 75 )
			};
			ash.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosAttribute.WeaponSpeed, 10 ), 
				new BonusAttribute( AosAttribute.LowerWeight, 75 ),
				new BonusAttribute( AosWeaponAttribute.LowerStatReq, 20 )
			};
			ash.ShieldAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Energy, 3 ),
				new BonusAttribute( AosArmorAttribute.LowerStatReq, 20 )
			};
			ash.OtherAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosArmorAttribute.LowerStatReq, 20 ) 
			};
			ash.RunicMinAttributes = 2;
			ash.RunicMaxAttributes = 3;
			ash.RunicMinIntensity = 35;
			ash.RunicMaxIntensity = 75;

			CraftAttributeInfo yew = YewWood = new CraftAttributeInfo();

			yew.ArmorAttributes = new BonusAttribute[] {
				new BonusAttribute( ResistanceType.Physical, 6 ),
				new BonusAttribute( ResistanceType.Fire, 3 ),
				new BonusAttribute( ResistanceType.Cold, 3 ),
				new BonusAttribute( ResistanceType.Energy, 3 ),
				new BonusAttribute( AosAttribute.RegenHits, 1 ) 
			};
			yew.WeaponAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.WeaponDamage, 10 ),
				new BonusAttribute( AosAttribute.AttackChance, 5 )
			};
			yew.ShieldAttributes = new BonusAttribute[] {
				new BonusAttribute( ResistanceType.Physical, 3 ),
				new BonusAttribute( AosAttribute.RegenHits, 1 ) 
			};
			yew.OtherAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosAttribute.RegenHits, 2 ) 
			};
			yew.RunicMinAttributes = 3;
			yew.RunicMaxAttributes = 3;
			yew.RunicMinIntensity = 40;
			yew.RunicMaxIntensity = 90;

			CraftAttributeInfo heart = Heartwood = new CraftAttributeInfo();
			
			heart.ArmorAttributes = new BonusAttribute[] {
				new BonusAttribute( ResistanceType.Physical, 2 ),
				new BonusAttribute( ResistanceType.Fire, 3 ),
				new BonusAttribute( ResistanceType.Cold, 2 ),
				new BonusAttribute( ResistanceType.Poison, 7 ),
				new BonusAttribute( ResistanceType.Energy, 2 )
			};
			
			#region Random Attributes
			heart.RandomAttributeCount = 1;
			heart.ArmorRandomAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosArmorAttribute.DurabilityBonus, 50 ),
				new BonusAttribute( AosArmorAttribute.LowerStatReq, 20 ),
				new BonusAttribute( AosAttribute.WeaponDamage, 10 ),
				new BonusAttribute( AosAttribute.LowerWeight, 50 ),
				new BonusAttribute( AosAttribute.AttackChance, 5 ),
				new BonusAttribute( AosArmorAttribute.MageArmor, 1 )
			};
			
			heart.WeaponRandomAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosWeaponAttribute.DurabilityBonus, 50 ),
				new BonusAttribute( AosWeaponAttribute.LowerStatReq, 20 ),
				new BonusAttribute( AosAttribute.WeaponSpeed, 10 ),
				new BonusAttribute( AosAttribute.LowerWeight, 75 ),
				new BonusAttribute( AosAttribute.AttackChance, 5 ),
				new BonusAttribute( AosWeaponAttribute.HitLeechHits, 13 ),
				new BonusAttribute( AosAttribute.Luck, 10 )
			};
			
			heart.ShieldRandomAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.BonusDex, 2 ),
				new BonusAttribute( AosAttribute.BonusStr, 2 ),
				new BonusAttribute( ResistanceType.Physical, 5 ),
				new BonusAttribute( AosAttribute.ReflectPhysical, 5 ),
				new BonusAttribute( AosArmorAttribute.SelfRepair, 2 ),
				new BonusAttribute( ResistanceType.Cold, 3 ),
				new BonusAttribute( AosAttribute.SpellChanneling, 1 )
			};
			
			heart.OtherRandomAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosAttribute.RegenHits, 2 ),
				new BonusAttribute( AosArmorAttribute.LowerStatReq, 20 ),
				new BonusAttribute( AosAttribute.SpellChanneling, 1 ),
				new BonusAttribute( AosAttribute.Luck, 10 )
			};
			#endregion
			
			heart.RunicMinAttributes = 4;
			heart.RunicMaxAttributes = 4;
			heart.RunicMinIntensity = 50;
			heart.RunicMaxIntensity = 100;

			CraftAttributeInfo blood = Bloodwood = new CraftAttributeInfo();
			
			blood.ArmorAttributes = new BonusAttribute[] {
				new BonusAttribute( ResistanceType.Physical, 3 ),
				new BonusAttribute( ResistanceType.Fire, 8 ),
				new BonusAttribute( ResistanceType.Cold, 1 ),
				new BonusAttribute( ResistanceType.Poison, 3 ),
				new BonusAttribute( ResistanceType.Energy, 3 ),
				new BonusAttribute( AosAttribute.RegenHits, 2 ) 
			};
			blood.WeaponAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.RegenHits, 2 ),
				new BonusAttribute( AosWeaponAttribute.HitLeechHits, 13 )
			};
			blood.ShieldAttributes = new BonusAttribute[] {
				new BonusAttribute( ResistanceType.Fire, 3 ),
				new BonusAttribute( AosAttribute.Luck, 40 ),
				new BonusAttribute( AosAttribute.RegenHits, 2 ) 
			};
			blood.OtherAttributes = new BonusAttribute[] {
				new BonusAttribute( AosAttribute.RegenHits, 2 ),
				new BonusAttribute( AosAttribute.Luck, 20 )
			};

			CraftAttributeInfo frost = Frostwood = new CraftAttributeInfo();
			
			frost.ArmorAttributes = new BonusAttribute[] {
				new BonusAttribute( ResistanceType.Physical, 2 ),
				new BonusAttribute( ResistanceType.Fire, 1 ),
				new BonusAttribute( ResistanceType.Cold, 8 ),
				new BonusAttribute( ResistanceType.Poison, 3 ),
				new BonusAttribute( ResistanceType.Energy, 4 )
			};
			blood.WeaponAttributes = new BonusAttribute[] {
				
				new BonusAttribute( AosWeaponAttribute.HitLeechHits, 13 )
			};
			frost.WeaponAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosElementAttribute.Cold, 40 ),
				new BonusAttribute( AosAttribute.WeaponDamage, 12 ) 
			};
			frost.ShieldAttributes = new BonusAttribute[] { 
				new BonusAttribute( ResistanceType.Cold, 3 ),
				new BonusAttribute( AosAttribute.SpellChanneling, 1 ) 
			};
			frost.OtherAttributes = new BonusAttribute[] { 
				new BonusAttribute( AosAttribute.SpellChanneling, 1 )
			};
			#endregion
		}
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Number;
		private string m_Name;
		private CraftAttributeInfo m_AttributeInfo;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue{ get{ return m_Hue; } }
		public int Number{ get{ return m_Number; } }
		public string Name{ get{ return m_Name; } }
		public CraftAttributeInfo AttributeInfo{ get{ return m_AttributeInfo; } }
		public CraftResource Resource{ get{ return m_Resource; } }
		public Type[] ResourceTypes{ get{ return m_ResourceTypes; } }

		public CraftResourceInfo( int hue, int number, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes )
		{
			m_Hue = hue;
			m_Number = number;
			m_Name = name;
			m_AttributeInfo = attributeInfo;
			m_Resource = resource;
			m_ResourceTypes = resourceTypes;

			for ( int i = 0; i < resourceTypes.Length; ++i )
				CraftResources.RegisterType( resourceTypes[i], resource );
		}
	}

	public class CraftResources
	{
		private static CraftResourceInfo[] m_MetalInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1053109, "Iron",			CraftAttributeInfo.Blank,		CraftResource.Iron,				typeof( IronIngot ),		typeof( IronOre ),			typeof( Granite ) ),
				new CraftResourceInfo( 0x973, 1053108, "Dull Copper",	CraftAttributeInfo.DullCopper,	CraftResource.DullCopper,		typeof( DullCopperIngot ),	typeof( DullCopperOre ),	typeof( DullCopperGranite ) ),
				new CraftResourceInfo( 0x966, 1053107, "Shadow Iron",	CraftAttributeInfo.ShadowIron,	CraftResource.ShadowIron,		typeof( ShadowIronIngot ),	typeof( ShadowIronOre ),	typeof( ShadowIronGranite ) ),
				new CraftResourceInfo( 0x96D, 1053106, "Copper",		CraftAttributeInfo.Copper,		CraftResource.Copper,			typeof( CopperIngot ),		typeof( CopperOre ),		typeof( CopperGranite ) ),
				new CraftResourceInfo( 0x972, 1053105, "Bronze",		CraftAttributeInfo.Bronze,		CraftResource.Bronze,			typeof( BronzeIngot ),		typeof( BronzeOre ),		typeof( BronzeGranite ) ),
				new CraftResourceInfo( 0x8A5, 1053104, "Gold",			CraftAttributeInfo.Golden,		CraftResource.Gold,				typeof( GoldIngot ),		typeof( GoldOre ),			typeof( GoldGranite ) ),
				new CraftResourceInfo( 0x979, 1053103, "Agapite",		CraftAttributeInfo.Agapite,		CraftResource.Agapite,			typeof( AgapiteIngot ),		typeof( AgapiteOre ),		typeof( AgapiteGranite ) ),
				new CraftResourceInfo( 0x89F, 1053102, "Verite",		CraftAttributeInfo.Verite,		CraftResource.Verite,			typeof( VeriteIngot ),		typeof( VeriteOre ),		typeof( VeriteGranite ) ),
				new CraftResourceInfo( 0x8AB, 1053101, "Valorite",		CraftAttributeInfo.Valorite,	CraftResource.Valorite,			typeof( ValoriteIngot ),	typeof( ValoriteOre ),		typeof( ValoriteGranite ) ),
			};

		private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x66D, 1053129, "Red Scales",	CraftAttributeInfo.RedScales,		CraftResource.RedScales,		typeof( RedScales ) ),
				new CraftResourceInfo( 0x8A8, 1053130, "Yellow Scales",	CraftAttributeInfo.YellowScales,	CraftResource.YellowScales,		typeof( YellowScales ) ),
				new CraftResourceInfo( 0x455, 1053131, "Black Scales",	CraftAttributeInfo.BlackScales,		CraftResource.BlackScales,		typeof( BlackScales ) ),
				new CraftResourceInfo( 0x851, 1053132, "Green Scales",	CraftAttributeInfo.GreenScales,		CraftResource.GreenScales,		typeof( GreenScales ) ),
				new CraftResourceInfo( 0x8FD, 1053133, "White Scales",	CraftAttributeInfo.WhiteScales,		CraftResource.WhiteScales,		typeof( WhiteScales ) ),
				new CraftResourceInfo( 0x8B0, 1053134, "Blue Scales",	CraftAttributeInfo.BlueScales,		CraftResource.BlueScales,		typeof( BlueScales ) )
			};

		private static CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
				new CraftResourceInfo( 0x283, 1049354, "Spined",		CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				new CraftResourceInfo( 0x227, 1049355, "Horned",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				new CraftResourceInfo( 0x1C1, 1049356, "Barbed",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) )
			};

		private static CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
				new CraftResourceInfo( 0x8AC, 1049354, "Spined",		CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				new CraftResourceInfo( 0x845, 1049355, "Horned",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				new CraftResourceInfo( 0x851, 1049356, "Barbed",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) ),
			};

		private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1011542, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularWood,	typeof( Log ),			typeof( Board ) ),
				new CraftResourceInfo( 0x7DA, 1072533, "Oak",			CraftAttributeInfo.OakWood,		CraftResource.OakWood,		typeof( OakLog ),		typeof( OakBoard ) ),
				new CraftResourceInfo( 0x4A7, 1072534, "Ash",			CraftAttributeInfo.AshWood,		CraftResource.AshWood,		typeof( AshLog ),		typeof( AshBoard ) ),
				new CraftResourceInfo( 0x4A8, 1072535, "Yew",			CraftAttributeInfo.YewWood,		CraftResource.YewWood,		typeof( YewLog ),		typeof( YewBoard ) ),
				new CraftResourceInfo( 0x4A9, 1072536, "Heartwood",		CraftAttributeInfo.Heartwood,	CraftResource.Heartwood,	typeof( HeartwoodLog ),	typeof( HeartwoodBoard ) ),
				new CraftResourceInfo( 0x4AA, 1072538, "Bloodwood",		CraftAttributeInfo.Bloodwood,	CraftResource.Bloodwood,	typeof( BloodwoodLog ),	typeof( BloodwoodBoard ) ),
				new CraftResourceInfo( 0x47F, 1072539, "Frostwood",		CraftAttributeInfo.Frostwood,	CraftResource.Frostwood,	typeof( FrostwoodLog ),	typeof( FrostwoodBoard ) )
			};

		/// <summary>
		/// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
		/// </summary>
		public static bool IsStandard( CraftResource resource )
		{
			return ( resource == CraftResource.None || resource == CraftResource.Iron || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood );
		}

		private static Hashtable m_TypeTable;

		/// <summary>
		/// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="CraftResources.GetFromType"/>
		/// </summary>
		public static void RegisterType( Type resourceType, CraftResource resource )
		{
			if ( m_TypeTable == null )
				m_TypeTable = new Hashtable();

			m_TypeTable[resourceType] = resource;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
		/// </summary>
		public static CraftResource GetFromType( Type resourceType )
		{
			if ( m_TypeTable == null )
				return CraftResource.None;

			object obj = m_TypeTable[resourceType];

			if ( !(obj is CraftResource) )
				return CraftResource.None;

			return (CraftResource)obj;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
		/// </summary>
		public static CraftResourceInfo GetInfo( CraftResource resource )
		{
			CraftResourceInfo[] list = null;

			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: list = m_MetalInfo; break;
				case CraftResourceType.Leather: list = Core.AOS ? m_AOSLeatherInfo : m_LeatherInfo; break;
				case CraftResourceType.Scales: list = m_ScaleInfo; break;
				case CraftResourceType.Wood: list = m_WoodInfo; break;
			}

			if ( list != null )
			{
				int index = GetIndex( resource );

				if ( index >= 0 && index < list.Length )
					return list[index];
			}

			return null;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
		/// </summary>
		public static CraftResourceType GetType( CraftResource resource )
		{
			if ( resource >= CraftResource.Iron && resource <= CraftResource.Valorite )
				return CraftResourceType.Metal;

			if ( resource >= CraftResource.RegularLeather && resource <= CraftResource.BarbedLeather )
				return CraftResourceType.Leather;

			if ( resource >= CraftResource.RedScales && resource <= CraftResource.BlueScales )
				return CraftResourceType.Scales;

			if ( resource >= CraftResource.RegularWood && resource <= CraftResource.Frostwood )
				return CraftResourceType.Wood;

			return CraftResourceType.None;
		}

		/// <summary>
		/// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
		/// </summary>
		public static CraftResource GetStart( CraftResource resource )
		{
			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: return CraftResource.Iron;
				case CraftResourceType.Leather: return CraftResource.RegularLeather;
				case CraftResourceType.Scales: return CraftResource.RedScales;
				case CraftResourceType.Wood: return CraftResource.RegularWood;
			}

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
		/// </summary>
		public static int GetIndex( CraftResource resource )
		{
			CraftResource start = GetStart( resource );

			if ( start == CraftResource.None )
				return 0;

			return (int)(resource - start);
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetLocalizationNumber( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Number );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetHue( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Hue );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
		/// </summary>
		public static string GetName( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? String.Empty : info.Name );
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info )
		{
			if ( info.Name.IndexOf( "Spined" ) >= 0 )
				return CraftResource.SpinedLeather;
			else if ( info.Name.IndexOf( "Horned" ) >= 0 )
				return CraftResource.HornedLeather;
			else if ( info.Name.IndexOf( "Barbed" ) >= 0 )
				return CraftResource.BarbedLeather;
			else if ( info.Name.IndexOf( "Leather" ) >= 0 )
				return CraftResource.RegularLeather;

			if ( info.Level == 0 )
				return CraftResource.Iron;
			else if ( info.Level == 1 )
				return CraftResource.DullCopper;
			else if ( info.Level == 2 )
				return CraftResource.ShadowIron;
			else if ( info.Level == 3 )
				return CraftResource.Copper;
			else if ( info.Level == 4 )
				return CraftResource.Bronze;
			else if ( info.Level == 5 )
				return CraftResource.Gold;
			else if ( info.Level == 6 )
				return CraftResource.Agapite;
			else if ( info.Level == 7 )
				return CraftResource.Verite;
			else if ( info.Level == 8 )
				return CraftResource.Valorite;

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info, ArmorMaterialType material )
		{
			if ( material == ArmorMaterialType.Studded || material == ArmorMaterialType.Leather || material == ArmorMaterialType.Spined ||
				material == ArmorMaterialType.Horned || material == ArmorMaterialType.Barbed )
			{
				if ( info.Level == 0 )
					return CraftResource.RegularLeather;
				else if ( info.Level == 1 )
					return CraftResource.SpinedLeather;
				else if ( info.Level == 2 )
					return CraftResource.HornedLeather;
				else if ( info.Level == 3 )
					return CraftResource.BarbedLeather;

				return CraftResource.None;
			}

			return GetFromOreInfo( info );
		}
	}

	// NOTE: This class is only for compatability with very old RunUO versions.
	// No changes to it should be required for custom resources.
	public class OreInfo
	{
		public static readonly OreInfo Iron			= new OreInfo( 0, 0x000, "Iron" );
		public static readonly OreInfo DullCopper	= new OreInfo( 1, 0x973, "Dull Copper" );
		public static readonly OreInfo ShadowIron	= new OreInfo( 2, 0x966, "Shadow Iron" );
		public static readonly OreInfo Copper		= new OreInfo( 3, 0x96D, "Copper" );
		public static readonly OreInfo Bronze		= new OreInfo( 4, 0x972, "Bronze" );
		public static readonly OreInfo Gold			= new OreInfo( 5, 0x8A5, "Gold" );
		public static readonly OreInfo Agapite		= new OreInfo( 6, 0x979, "Agapite" );
		public static readonly OreInfo Verite		= new OreInfo( 7, 0x89F, "Verite" );
		public static readonly OreInfo Valorite		= new OreInfo( 8, 0x8AB, "Valorite" );

		private int m_Level;
		private int m_Hue;
		private string m_Name;

		public OreInfo( int level, int hue, string name )
		{
			m_Level = level;
			m_Hue = hue;
			m_Name = name;
		}

		public int Level
		{
			get
			{
				return m_Level;
			}
		}

		public int Hue
		{
			get
			{
				return m_Hue;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
		}
	}
}