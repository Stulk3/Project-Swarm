﻿// Shapes © Freya Holmér - https://twitter.com/FreyaHolmer/
// Website & Documentation - https://acegikmo.com/shapes/

namespace Shapes {

	/// <summary>Dash style, space &amp; size settings</summary>
	[System.Serializable]
	public class DashStyle {

		public static DashStyle DefaultDashStyleRing => new DashStyle( 16 ) { spacing = 0.5f, snap = DashSnapping.Tiling, space = DashSpace.FixedCount };
		public static DashStyle DefaultDashStyleLine => new DashStyle( 4 );

		/// <summary>The type of dash to use</summary>
		public DashType type = DashType.Basic;

		/// <summary>The space in which dashes are defined</summary>
		public DashSpace space = DashSpace.Relative;

		/// <summary>What snapping type to use</summary>
		public DashSnapping snap = DashSnapping.Off;

		/// <summary>Size of dashes in the specified dash space. When using DashSpace.FixedCount, this is the number of dashes</summary>
		public float size = 1f;

		/// <summary>An offset of 1 is the size of a whole dash+space period</summary>
		public float offset = 0f;

		/// <summary>Size of spacing between each dash, in the specified dash space. When using DashSpace.FixedCount, this is the dash:space ratio</summary>
		public float spacing = 1f;

		/// <summary>-1 to 1 modifier that allows you to tweak or mirror certain dash types</summary>
		[UnityEngine.Range( -1f, 1f )] public float shapeModifier = 1f;

		float GetNet( float v, float thickness ) => space == DashSpace.Relative ? thickness * v : v;
		public float GetNetAbsoluteSize( bool dashed, float thickness ) => dashed ? GetNet( size, thickness ) : 0f;
		public float GetNetAbsoluteSpacing( bool dashed, float thickness ) => dashed ? GetNet( spacing, thickness ) : 0f;

		/// <summary>
		/// Sets both size and spacing to the same value
		/// </summary>
		public float UniformSize {
			get => size; // a lil weird but it's okay
			set {
				size = value;
				if( space == DashSpace.FixedCount )
					spacing = 0.5f;
				else
					spacing = size;
			}
		}

		public DashStyle() {
		}

		public DashStyle( float size ) {
			this.size = size;
			this.spacing = size;
		}

		public DashStyle( float size, DashType type ) {
			this.size = size;
			this.spacing = size;
			this.type = type;
		}

		public DashStyle( float size, float spacing, DashType type ) {
			this.size = size;
			this.spacing = spacing;
			this.type = type;
		}

		public DashStyle( float size, float spacing ) {
			this.size = size;
			this.spacing = spacing;
		}

		public DashStyle( float size, float spacing, float offset ) {
			this.size = size;
			this.spacing = spacing;
			this.offset = offset;
		}

		public static implicit operator DashStyle( float dashSize ) => new DashStyle( dashSize );
		public static implicit operator DashStyle( int dashSize ) => new DashStyle( dashSize );
		public static implicit operator DashStyle( (float size, float spacing) t ) => new DashStyle( t.size, t.spacing );
		public static implicit operator DashStyle( (float size, float spacing, float offset) t ) => new DashStyle( t.size, t.spacing, t.offset );

	}

}