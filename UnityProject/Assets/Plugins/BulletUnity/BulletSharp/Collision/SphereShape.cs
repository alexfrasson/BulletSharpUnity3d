using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class SphereShape : ConvexInternalShape
	{
		public SphereShape(double radius)
			: base(btSphereShape_new(radius))
		{
		}

		public void SetUnscaledRadius(double radius)
		{
			btSphereShape_setUnscaledRadius(_native, radius);
		}

		public double Radius
		{
			get { return btSphereShape_getRadius(_native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSphereShape_new(double radius);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSphereShape_getRadius(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSphereShape_setUnscaledRadius(IntPtr obj, double radius);
	}
}
