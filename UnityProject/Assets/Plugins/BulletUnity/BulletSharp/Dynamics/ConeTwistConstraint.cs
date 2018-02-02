using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;

namespace BulletSharp
{
	[Flags]
	public enum ConeTwistFlags
	{
		None = 0,
		LinearCfm = 1,
		LinearErp = 2,
		AngularCfm = 4
	}

	public class ConeTwistConstraint : TypedConstraint
	{
		public ConeTwistConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Matrix rigidBodyAFrame, Matrix rigidBodyBFrame)
			: base(btConeTwistConstraint_new(rigidBodyA._native, rigidBodyB._native, ref rigidBodyAFrame, ref rigidBodyBFrame))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public ConeTwistConstraint(RigidBody rigidBodyA, Matrix rigidBodyAFrame)
			: base(btConeTwistConstraint_new2(rigidBodyA._native, ref rigidBodyAFrame))
		{
			_rigidBodyA = rigidBodyA;
            _rigidBodyB = GetFixedBody();
		}

		public void CalcAngleInfo()
		{
			btConeTwistConstraint_calcAngleInfo(_native);
		}

        public void CalcAngleInfo2(ref Matrix transA, ref Matrix transB, ref Matrix invInertiaWorldA, ref Matrix invInertiaWorldB)
		{
			btConeTwistConstraint_calcAngleInfo2(_native, ref transA, ref transB, ref invInertiaWorldA, ref invInertiaWorldB);
		}

		public void EnableMotor(bool b)
		{
			btConeTwistConstraint_enableMotor(_native, b);
		}

		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btConeTwistConstraint_getInfo1NonVirtual(_native, info._native);
		}

		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix transA, Matrix transB, Matrix invInertiaWorldA, Matrix invInertiaWorldB)
		{
			btConeTwistConstraint_getInfo2NonVirtual(_native, info._native, ref transA, ref transB, ref invInertiaWorldA, ref invInertiaWorldB);
		}

		public double GetLimit(int limitIndex)
		{
			return btConeTwistConstraint_getLimit(_native, limitIndex);
		}

		public Vector3 GetPointForAngle(double fAngleInRadians, double fLength)
		{
			Vector3 value;
			btConeTwistConstraint_GetPointForAngle(_native, fAngleInRadians, fLength, out value);
			return value;
		}

        public void SetFramesRef(ref Matrix frameA, ref Matrix frameB)
        {
            btConeTwistConstraint_setFrames(_native, ref frameA, ref frameB);
        }

		public void SetFrames(Matrix frameA, Matrix frameB)
		{
			btConeTwistConstraint_setFrames(_native, ref frameA, ref frameB);
		}

		public void SetLimit(int limitIndex, double limitValue)
		{
			btConeTwistConstraint_setLimit(_native, limitIndex, limitValue);
		}

		public void SetLimit(double swingSpan1, double swingSpan2, double twistSpan)
		{
			btConeTwistConstraint_setLimit2(_native, swingSpan1, swingSpan2, twistSpan);
		}

		public void SetLimit(double swingSpan1, double swingSpan2, double twistSpan, double softness)
		{
			btConeTwistConstraint_setLimit3(_native, swingSpan1, swingSpan2, twistSpan, softness);
		}

		public void SetLimit(double swingSpan1, double swingSpan2, double twistSpan, double softness, double biasFactor)
		{
			btConeTwistConstraint_setLimit4(_native, swingSpan1, swingSpan2, twistSpan, softness, biasFactor);
		}

		public void SetLimit(double swingSpan1, double swingSpan2, double twistSpan, double softness, double biasFactor, double relaxationFactor)
		{
			btConeTwistConstraint_setLimit5(_native, swingSpan1, swingSpan2, twistSpan, softness, biasFactor, relaxationFactor);
		}

		public void SetMaxMotorImpulseNormalized(double maxMotorImpulse)
		{
			btConeTwistConstraint_setMaxMotorImpulseNormalized(_native, maxMotorImpulse);
		}

		public void SetMotorTargetInConstraintSpace(Quaternion q)
		{
			btConeTwistConstraint_setMotorTargetInConstraintSpace(_native, ref q);
		}

		public void UpdateRhs(double timeStep)
		{
			btConeTwistConstraint_updateRHS(_native, timeStep);
		}

		public Matrix AFrame
		{
			get
			{
				Matrix value;
				btConeTwistConstraint_getAFrame(_native, out value);
				return value;
			}
		}

		public bool AngularOnly
		{
			get { return btConeTwistConstraint_getAngularOnly(_native); }
			set { btConeTwistConstraint_setAngularOnly(_native, value); }
		}

		public Matrix BFrame
		{
			get
			{
				Matrix value;
				btConeTwistConstraint_getBFrame(_native, out value);
				return value;
			}
		}

		public double BiasFactor
		{
			get { return btConeTwistConstraint_getBiasFactor(_native); }
		}

		public double Damping
		{
			get { return btConeTwistConstraint_getDamping(_native); }
			set { btConeTwistConstraint_setDamping(_native, value); }
		}

		public double FixThresh
		{
			get { return btConeTwistConstraint_getFixThresh(_native); }
			set { btConeTwistConstraint_setFixThresh(_native, value); }
		}

		public ConeTwistFlags Flags
		{
			get { return btConeTwistConstraint_getFlags(_native); }
		}

		public Matrix FrameOffsetA
		{
			get
			{
				Matrix value;
				btConeTwistConstraint_getFrameOffsetA(_native, out value);
				return value;
			}
		}

		public Matrix FrameOffsetB
		{
			get
			{
				Matrix value;
				btConeTwistConstraint_getFrameOffsetB(_native, out value);
				return value;
			}
		}

		public bool IsMaxMotorImpulseNormalized
		{
			get { return btConeTwistConstraint_isMaxMotorImpulseNormalized(_native); }
		}

		public bool IsMotorEnabled
		{
			get { return btConeTwistConstraint_isMotorEnabled(_native); }
		}

		public bool IsPastSwingLimit
		{
			get { return btConeTwistConstraint_isPastSwingLimit(_native); }
		}

		public double LimitSoftness
		{
			get { return btConeTwistConstraint_getLimitSoftness(_native); }
		}

		public double MaxMotorImpulse
		{
			get { return btConeTwistConstraint_getMaxMotorImpulse(_native); }
			set { btConeTwistConstraint_setMaxMotorImpulse(_native, value); }
		}

		public Quaternion MotorTarget
		{
			get
			{
				Quaternion value;
				btConeTwistConstraint_getMotorTarget(_native, out value);
				return value;
			}
			set { btConeTwistConstraint_setMotorTarget(_native, ref value); }
		}

		public double RelaxationFactor
		{
			get { return btConeTwistConstraint_getRelaxationFactor(_native); }
		}

		public int SolveSwingLimit
		{
			get { return btConeTwistConstraint_getSolveSwingLimit(_native); }
		}

		public int SolveTwistLimit
		{
			get { return btConeTwistConstraint_getSolveTwistLimit(_native); }
		}

		public double SwingSpan1
		{
			get { return btConeTwistConstraint_getSwingSpan1(_native); }
		}

		public double SwingSpan2
		{
			get { return btConeTwistConstraint_getSwingSpan2(_native); }
		}

		public double TwistAngle
		{
			get { return btConeTwistConstraint_getTwistAngle(_native); }
		}

		public double TwistLimitSign
		{
			get { return btConeTwistConstraint_getTwistLimitSign(_native); }
		}

		public double TwistSpan
		{
			get { return btConeTwistConstraint_getTwistSpan(_native); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConeTwistConstraint_new(IntPtr rbA, IntPtr rbB, [In] ref Matrix rbAFrame, [In] ref Matrix rbBFrame);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConeTwistConstraint_new2(IntPtr rbA, [In] ref Matrix rbAFrame);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_calcAngleInfo(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_calcAngleInfo2(IntPtr obj, [In] ref Matrix transA, [In] ref Matrix transB, [In] ref Matrix invInertiaWorldA, [In] ref Matrix invInertiaWorldB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_enableMotor(IntPtr obj, bool b);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_getAFrame(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btConeTwistConstraint_getAngularOnly(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_getBFrame(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getBiasFactor(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getDamping(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getFixThresh(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern ConeTwistFlags btConeTwistConstraint_getFlags(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_getFrameOffsetA(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_getFrameOffsetB(IntPtr obj, [Out] out Matrix value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_getInfo1NonVirtual(IntPtr obj, IntPtr info);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_getInfo2NonVirtual(IntPtr obj, IntPtr info, [In] ref Matrix transA, [In] ref Matrix transB, [In] ref Matrix invInertiaWorldA, [In] ref Matrix invInertiaWorldB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getLimit(IntPtr obj, int limitIndex);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getLimitSoftness(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getMaxMotorImpulse(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_getMotorTarget(IntPtr obj, [Out] out Quaternion q);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_GetPointForAngle(IntPtr obj, double fAngleInRadians, double fLength, [Out] out Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getRelaxationFactor(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btConeTwistConstraint_getSolveSwingLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btConeTwistConstraint_getSolveTwistLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getSwingSpan1(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getSwingSpan2(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getTwistAngle(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getTwistLimitSign(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern double btConeTwistConstraint_getTwistSpan(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btConeTwistConstraint_isMaxMotorImpulseNormalized(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btConeTwistConstraint_isMotorEnabled(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btConeTwistConstraint_isPastSwingLimit(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setAngularOnly(IntPtr obj, bool angularOnly);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setDamping(IntPtr obj, double damping);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setFixThresh(IntPtr obj, double fixThresh);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setFrames(IntPtr obj, [In] ref Matrix frameA, [In] ref Matrix frameB);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setLimit(IntPtr obj, int limitIndex, double limitValue);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setLimit2(IntPtr obj, double _swingSpan1, double _swingSpan2, double _twistSpan);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setLimit3(IntPtr obj, double _swingSpan1, double _swingSpan2, double _twistSpan, double _softness);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setLimit4(IntPtr obj, double _swingSpan1, double _swingSpan2, double _twistSpan, double _softness, double _biasFactor);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setLimit5(IntPtr obj, double _swingSpan1, double _swingSpan2, double _twistSpan, double _softness, double _biasFactor, double _relaxationFactor);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setMaxMotorImpulse(IntPtr obj, double maxMotorImpulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setMaxMotorImpulseNormalized(IntPtr obj, double maxMotorImpulse);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setMotorTarget(IntPtr obj, [In] ref Quaternion q);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_setMotorTargetInConstraintSpace(IntPtr obj, [In] ref Quaternion q);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConeTwistConstraint_updateRHS(IntPtr obj, double timeStep);
	}

    [StructLayout(LayoutKind.Sequential)]
    internal struct ConeTwistConstraintFloatData
    {
        public TypedConstraintFloatData TypedConstraintData;
        public TransformFloatData RigidBodyAFrame;
        public TransformFloatData RigidBodyBFrame;
        public double SwingSpan1;
        public double SwingSpan2;
        public double TwistSpan;
        public double LimitSoftness;
        public double BiasFactor;
        public double RelaxationFactor;
        public double Damping;
        public int Pad;

        public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(ConeTwistConstraintFloatData), fieldName).ToInt32(); }
    }
}
