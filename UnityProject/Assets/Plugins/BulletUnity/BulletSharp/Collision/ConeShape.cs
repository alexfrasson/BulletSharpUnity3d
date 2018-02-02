using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class ConeShape : ConvexInternalShape
	{
		internal ConeShape(IntPtr native)
			: base(native)
		{
		}

		public ConeShape(double radius, double height)
			: base(btConeShape_new(radius, height))
		{
		}

		public int ConeUpIndex
		{
			get { return btConeShape_getConeUpIndex(_native); }
			set { btConeShape_setConeUpIndex(_native, value); }
		}

		public double Height
		{
			get { return btConeShape_getHeight(_native); }
		}

		public double Radius
		{
			get { return btConeShape_getRadius(_native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConeShape_new(double radius, double height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btConeShape_getConeUpIndex(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeShape_getHeight(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeShape_getRadius(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeShape_setConeUpIndex(IntPtr obj, int upIndex);
	}

	public class ConeShapeX : ConeShape
	{
		public ConeShapeX(double radius, double height)
			: base(btConeShapeX_new(radius, height))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConeShapeX_new(double radius, double height);
	}

	public class ConeShapeZ : ConeShape
	{
		public ConeShapeZ(double radius, double height)
			: base(btConeShapeZ_new(radius, height))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConeShapeZ_new(double radius, double height);
	}
}
