using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;

namespace BulletSharp
{
	[Flags]
	public enum SliderFlags
	{
		None = 0,
		CfmDirLinear = 1,
		ErpDirLinear = 2,
		CfmDirAngular = 4,
		ErpDirAngular = 8,
		CfmOrthoLinear = 16,
		ErpOrthoLinear = 32,
		CfmOrthoAngular = 64,
		ErpOrthoAngular = 128,
		CfmLimitLinear = 512,
		ErpLimitLinear = 1024,
		CfmLimitAngular = 2048,
		ErpLimitAngular = 4096
	}

	public class SliderConstraint : TypedConstraint
	{
		public SliderConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Matrix frameInA, Matrix frameInB, bool useLinearReferenceFrameA)
			: base(btSliderConstraint_new(rigidBodyA._native, rigidBodyB._native, ref frameInA, ref frameInB, useLinearReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public SliderConstraint(RigidBody rigidBodyB, Matrix frameInB, bool useLinearReferenceFrameA)
			: base(btSliderConstraint_new2(rigidBodyB._native, ref frameInB, useLinearReferenceFrameA))
		{
            _rigidBodyA = GetFixedBody();
			_rigidBodyB = rigidBodyB;
		}

        public void CalculateTransformsRef(ref Matrix transA, ref Matrix transB)
        {
            btSliderConstraint_calculateTransforms(_native, ref transA, ref transB);
        }

		public void CalculateTransforms(Matrix transA, Matrix transB)
		{
			btSliderConstraint_calculateTransforms(_native, ref transA, ref transB);
		}

		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btSliderConstraint_getInfo1NonVirtual(_native, info._native);
		}

		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix transA, Matrix transB, Vector3 linVelA, Vector3 linVelB, double rbAinvMass, double rbBinvMass)
		{
			btSliderConstraint_getInfo2NonVirtual(_native, info._native, ref transA, ref transB, ref linVelA, ref linVelB, rbAinvMass, rbBinvMass);
		}

        public void SetFramesRef(ref Matrix frameA, ref Matrix frameB)
        {
            btSliderConstraint_setFrames(_native, ref frameA, ref frameB);
        }

		public void SetFrames(Matrix frameA, Matrix frameB)
		{
			btSliderConstraint_setFrames(_native, ref frameA, ref frameB);
		}

		public void TestAngularLimits()
		{
			btSliderConstraint_testAngLimits(_native);
		}

		public void TestLinearLimits()
		{
			btSliderConstraint_testLinLimits(_native);
		}

		public Vector3 AncorInA
		{
			get
			{
				Vector3 value;
				btSliderConstraint_getAncorInA(_native, out value);
				return value;
			}
		}

		public Vector3 AncorInB
		{
			get
			{
				Vector3 value;
				btSliderConstraint_getAncorInB(_native, out value);
				return value;
			}
		}

		public double AngularDepth
		{
			get { return btSliderConstraint_getAngDepth(_native); }
		}

		public double AngularPosition
		{
			get { return btSliderConstraint_getAngularPos(_native); }
		}

		public Matrix CalculatedTransformA
		{
			get
			{
				Matrix value;
				btSliderConstraint_getCalculatedTransformA(_native, out value);
				return value;
			}
		}

		public Matrix CalculatedTransformB
		{
			get
			{
				Matrix value;
				btSliderConstraint_getCalculatedTransformB(_native, out value);
				return value;
			}
		}

		public double DampingDirAngular
		{
			get { return btSliderConstraint_getDampingDirAng(_native); }
			set { btSliderConstraint_setDampingDirAng(_native, value); }
		}

		public double DampingDirLinear
		{
			get { return btSliderConstraint_getDampingDirLin(_native); }
			set { btSliderConstraint_setDampingDirLin(_native, value); }
		}

		public double DampingLimAngular
		{
			get { return btSliderConstraint_getDampingLimAng(_native); }
			set { btSliderConstraint_setDampingLimAng(_native, value); }
		}

		public double DampingLimLinear
		{
			get { return btSliderConstraint_getDampingLimLin(_native); }
			set { btSliderConstraint_setDampingLimLin(_native, value); }
		}

		public double DampingOrthoAngular
		{
			get { return btSliderConstraint_getDampingOrthoAng(_native); }
			set { btSliderConstraint_setDampingOrthoAng(_native, value); }
		}

		public double DampingOrthoLinear
		{
			get { return btSliderConstraint_getDampingOrthoLin(_native); }
			set { btSliderConstraint_setDampingOrthoLin(_native, value); }
		}

		public SliderFlags Flags
		{
			get { return btSliderConstraint_getFlags(_native); }
		}

		public Matrix FrameOffsetA
		{
			get
			{
				Matrix value;
				btSliderConstraint_getFrameOffsetA(_native, out value);
				return value;
			}
		}

		public Matrix FrameOffsetB
		{
			get
			{
				Matrix value;
				btSliderConstraint_getFrameOffsetB(_native, out value);
				return value;
			}
		}

		public double LinearDepth
		{
			get { return btSliderConstraint_getLinDepth(_native); }
		}

		public double LinearPos
		{
			get { return btSliderConstraint_getLinearPos(_native); }
		}

		public double LowerAngularLimit
		{
			get { return btSliderConstraint_getLowerAngLimit(_native); }
			set { btSliderConstraint_setLowerAngLimit(_native, value); }
		}

		public double LowerLinearLimit
		{
			get { return btSliderConstraint_getLowerLinLimit(_native); }
			set { btSliderConstraint_setLowerLinLimit(_native, value); }
		}

		public double MaxAngMotorForce
		{
			get { return btSliderConstraint_getMaxAngMotorForce(_native); }
			set { btSliderConstraint_setMaxAngMotorForce(_native, value); }
		}

		public double MaxLinearMotorForce
		{
			get { return btSliderConstraint_getMaxLinMotorForce(_native); }
			set { btSliderConstraint_setMaxLinMotorForce(_native, value); }
		}

		public bool PoweredAngularMotor
		{
			get { return btSliderConstraint_getPoweredAngMotor(_native); }
			set { btSliderConstraint_setPoweredAngMotor(_native, value); }
		}

		public bool PoweredLinearMotor
		{
			get { return btSliderConstraint_getPoweredLinMotor(_native); }
			set { btSliderConstraint_setPoweredLinMotor(_native, value); }
		}

		public double RestitutionDirAngular
		{
			get { return btSliderConstraint_getRestitutionDirAng(_native); }
			set { btSliderConstraint_setRestitutionDirAng(_native, value); }
		}

		public double RestitutionDirLinear
		{
			get { return btSliderConstraint_getRestitutionDirLin(_native); }
			set { btSliderConstraint_setRestitutionDirLin(_native, value); }
		}

		public double RestitutionLimAngular
		{
			get { return btSliderConstraint_getRestitutionLimAng(_native); }
			set { btSliderConstraint_setRestitutionLimAng(_native, value); }
		}

		public double RestitutionLimLinear
		{
			get { return btSliderConstraint_getRestitutionLimLin(_native); }
			set { btSliderConstraint_setRestitutionLimLin(_native, value); }
		}

		public double RestitutionOrthoAngular
		{
			get { return btSliderConstraint_getRestitutionOrthoAng(_native); }
			set { btSliderConstraint_setRestitutionOrthoAng(_native, value); }
		}

		public double RestitutionOrthoLinear
		{
			get { return btSliderConstraint_getRestitutionOrthoLin(_native); }
			set { btSliderConstraint_setRestitutionOrthoLin(_native, value); }
		}

		public double SoftnessDirAngular
		{
			get { return btSliderConstraint_getSoftnessDirAng(_native); }
			set { btSliderConstraint_setSoftnessDirAng(_native, value); }
		}

		public double SoftnessDirLinear
		{
			get { return btSliderConstraint_getSoftnessDirLin(_native); }
			set { btSliderConstraint_setSoftnessDirLin(_native, value); }
		}

		public double SoftnessLimAngular
		{
			get { return btSliderConstraint_getSoftnessLimAng(_native); }
			set { btSliderConstraint_setSoftnessLimAng(_native, value); }
		}

		public double SoftnessLimLinear
		{
			get { return btSliderConstraint_getSoftnessLimLin(_native); }
			set { btSliderConstraint_setSoftnessLimLin(_native, value); }
		}

		public double SoftnessOrthoAngular
		{
			get { return btSliderConstraint_getSoftnessOrthoAng(_native); }
			set { btSliderConstraint_setSoftnessOrthoAng(_native, value); }
		}

		public double SoftnessOrthoLinear
		{
			get { return btSliderConstraint_getSoftnessOrthoLin(_native); }
			set { btSliderConstraint_setSoftnessOrthoLin(_native, value); }
		}

		public bool SolveAngularLimit
		{
			get { return btSliderConstraint_getSolveAngLimit(_native); }
		}

		public bool SolveLinearLimit
		{
			get { return btSliderConstraint_getSolveLinLimit(_native); }
		}

		public double TargetAngularMotorVelocity
		{
			get { return btSliderConstraint_getTargetAngMotorVelocity(_native); }
			set { btSliderConstraint_setTargetAngMotorVelocity(_native, value); }
		}

		public double TargetLinearMotorVelocity
		{
			get { return btSliderConstraint_getTargetLinMotorVelocity(_native); }
			set { btSliderConstraint_setTargetLinMotorVelocity(_native, value); }
		}

		public double UpperAngularLimit
		{
			get { return btSliderConstraint_getUpperAngLimit(_native); }
			set { btSliderConstraint_setUpperAngLimit(_native, value); }
		}

		public double UpperLinearLimit
		{
			get { return btSliderConstraint_getUpperLinLimit(_native); }
			set { btSliderConstraint_setUpperLinLimit(_native, value); }
		}

		public bool UseFrameOffset
		{
			get { return btSliderConstraint_getUseFrameOffset(_native); }
			set { btSliderConstraint_setUseFrameOffset(_native, value); }
		}

		public bool UseLinearReferenceFrameA
		{
			get { return btSliderConstraint_getUseLinearReferenceFrameA(_native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSliderConstraint_new(IntPtr rbA, IntPtr rbB, [In] ref Matrix frameInA, [In] ref Matrix frameInB, bool useLinearReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btSliderConstraint_new2(IntPtr rbB, [In] ref Matrix frameInB, bool useLinearReferenceFrameA);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_calculateTransforms(IntPtr obj, [In] ref Matrix transA, [In] ref Matrix transB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getAncorInA(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getAncorInB(IntPtr obj, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getAngDepth(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getAngularPos(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getCalculatedTransformA(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getCalculatedTransformB(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getDampingDirAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getDampingDirLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getDampingLimAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getDampingLimLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getDampingOrthoAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getDampingOrthoLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern SliderFlags btSliderConstraint_getFlags(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getFrameOffsetA(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getFrameOffsetB(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getInfo1NonVirtual(IntPtr obj, IntPtr info);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_getInfo2NonVirtual(IntPtr obj, IntPtr info, [In] ref Matrix transA, [In] ref Matrix transB, [In] ref Vector3 linVelA, [In] ref Vector3 linVelB, double rbAinvMass, double rbBinvMass);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getLinDepth(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getLinearPos(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getLowerAngLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getLowerLinLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getMaxAngMotorForce(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getMaxLinMotorForce(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSliderConstraint_getPoweredAngMotor(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSliderConstraint_getPoweredLinMotor(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getRestitutionDirAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getRestitutionDirLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getRestitutionLimAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getRestitutionLimLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getRestitutionOrthoAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getRestitutionOrthoLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getSoftnessDirAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getSoftnessDirLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getSoftnessLimAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getSoftnessLimLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getSoftnessOrthoAng(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getSoftnessOrthoLin(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSliderConstraint_getSolveAngLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSliderConstraint_getSolveLinLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getTargetAngMotorVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getTargetLinMotorVelocity(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getUpperAngLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btSliderConstraint_getUpperLinLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSliderConstraint_getUseFrameOffset(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btSliderConstraint_getUseLinearReferenceFrameA(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setDampingDirAng(IntPtr obj, double dampingDirAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setDampingDirLin(IntPtr obj, double dampingDirLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setDampingLimAng(IntPtr obj, double dampingLimAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setDampingLimLin(IntPtr obj, double dampingLimLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setDampingOrthoAng(IntPtr obj, double dampingOrthoAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setDampingOrthoLin(IntPtr obj, double dampingOrthoLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setFrames(IntPtr obj, [In] ref Matrix frameA, [In] ref Matrix frameB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setLowerAngLimit(IntPtr obj, double lowerLimit);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setLowerLinLimit(IntPtr obj, double lowerLimit);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setMaxAngMotorForce(IntPtr obj, double maxAngMotorForce);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setMaxLinMotorForce(IntPtr obj, double maxLinMotorForce);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setPoweredAngMotor(IntPtr obj, bool onOff);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setPoweredLinMotor(IntPtr obj, bool onOff);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setRestitutionDirAng(IntPtr obj, double restitutionDirAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setRestitutionDirLin(IntPtr obj, double restitutionDirLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setRestitutionLimAng(IntPtr obj, double restitutionLimAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setRestitutionLimLin(IntPtr obj, double restitutionLimLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setRestitutionOrthoAng(IntPtr obj, double restitutionOrthoAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setRestitutionOrthoLin(IntPtr obj, double restitutionOrthoLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setSoftnessDirAng(IntPtr obj, double softnessDirAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setSoftnessDirLin(IntPtr obj, double softnessDirLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setSoftnessLimAng(IntPtr obj, double softnessLimAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setSoftnessLimLin(IntPtr obj, double softnessLimLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setSoftnessOrthoAng(IntPtr obj, double softnessOrthoAng);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setSoftnessOrthoLin(IntPtr obj, double softnessOrthoLin);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setTargetAngMotorVelocity(IntPtr obj, double targetAngMotorVelocity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setTargetLinMotorVelocity(IntPtr obj, double targetLinMotorVelocity);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setUpperAngLimit(IntPtr obj, double upperLimit);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setUpperLinLimit(IntPtr obj, double upperLimit);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_setUseFrameOffset(IntPtr obj, bool frameOffsetOnOff);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_testAngLimits(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSliderConstraint_testLinLimits(IntPtr obj);
	}

    [StructLayout(LayoutKind.Sequential)]
    internal struct SliderConstraintFloatData
    {
        public TypedConstraintFloatData TypedConstraintData;
        public TransformFloatData RigidBodyAFrame;
        public TransformFloatData RigidBodyBFrame;
        public double LinearUpperLimit;
        public double LinearLowerLimit;
        public double AngularUpperLimit;
        public double AngularLowerLimit;
        public int UseLinearReferenceFrameA;
        public int UseOffsetForConstraintFrame;

        public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(SliderConstraintFloatData), fieldName).ToInt32(); }
    }
}
