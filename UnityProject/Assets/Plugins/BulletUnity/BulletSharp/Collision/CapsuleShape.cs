using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class CapsuleShape : ConvexInternalShape
	{
		internal CapsuleShape(IntPtr native)
			: base(native)
		{
		}

		public CapsuleShape(double radius, double height)
			: base(btCapsuleShape_new(radius, height))
		{
		}

		public double HalfHeight
		{
			get { return btCapsuleShape_getHalfHeight(_native); }
		}

		public double Radius
		{
			get { return btCapsuleShape_getRadius(_native); }
		}

		public int UpAxis
		{
			get { return btCapsuleShape_getUpAxis(_native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCapsuleShape_new(double radius, double height);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btCapsuleShape_getHalfHeight(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btCapsuleShape_getRadius(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btCapsuleShape_getUpAxis(IntPtr obj);
	}

	public class CapsuleShapeX : CapsuleShape
	{
		public CapsuleShapeX(double radius, double height)
			: base(btCapsuleShapeX_new(radius, height))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCapsuleShapeX_new(double radius, double height);
	}

	public class CapsuleShapeZ : CapsuleShape
	{
		public CapsuleShapeZ(double radius, double height)
			: base(btCapsuleShapeZ_new(radius, height))
		{
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btCapsuleShapeZ_new(double radius, double height);
	}
}
