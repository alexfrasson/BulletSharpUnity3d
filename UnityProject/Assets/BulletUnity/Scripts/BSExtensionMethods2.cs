using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Reflection;

namespace BulletUnity {
    public static class BSExtensionMethods2 {

        public static BulletSharp.Math.Quaternion ToBullet(this UnityEngine.Quaternion v) {
            return new BulletSharp.Math.Quaternion(v.x, v.y, v.z, v.w);
        }

        public static UnityEngine.Quaternion ToUnity(this BulletSharp.Math.Quaternion v) {
            return new UnityEngine.Quaternion((float)v.X, (float)v.Y, (float)v.Z, (float)v.W);
        }

        public static BulletSharp.Math.Vector3 ToBullet(this UnityEngine.Vector3 v) {
            return new BulletSharp.Math.Vector3(v.x, v.y, v.z);
        }

        public static UnityEngine.Vector3 ToUnity(this BulletSharp.Math.Vector3 v) {
            return new UnityEngine.Vector3((float)v.X, (float)v.Y, (float)v.Z);
        }

        public static UnityEngine.Matrix4x4 ToUnity(this BulletSharp.Math.Matrix bm) {
            Matrix4x4 um = new Matrix4x4();
            um[0, 0] = (float)bm[0, 0];
            um[0, 1] = (float)bm[1, 0];
            um[0, 2] = (float)bm[2, 0];
            um[0, 3] = (float)bm[3, 0];

            um[1, 0] = (float)bm[0, 1];
            um[1, 1] = (float)bm[1, 1];
            um[1, 2] = (float)bm[2, 1];
            um[1, 3] = (float)bm[3, 1];

            um[2, 0] = (float)bm[0, 2];
            um[2, 1] = (float)bm[1, 2];
            um[2, 2] = (float)bm[2, 2];
            um[2, 3] = (float)bm[3, 2];

            um[3, 0] = (float)bm[0, 3];
            um[3, 1] = (float)bm[1, 3];
            um[3, 2] = (float)bm[2, 3];
            um[3, 3] = (float)bm[3, 3];
            return um;
        }


        public static BulletSharp.Math.Quaternion GetOrientation(this BulletSharp.Math.Matrix bm)
        {
                /*
                double trace = M11 + M22 + M33;

                double[] temp = new double[4];

                if (trace > 0.0f)
                {
                    double s = UnityEngine.Mathf.Sqrt(trace + (1.0f));
                    temp[3] = (s * (0.5f));
                    s = (0.5f) / s;

                    temp[0] = ((M32 - M23) * s);
                    temp[1] = ((M13 - M31) * s);
                    temp[2] = ((M21 - M12) * s);

                    temp[0] = ((M23 - M32) * s);
                    temp[1] = ((M31 - M13) * s);
                    temp[2] = ((M12 - M21) * s);
                }
                else
                {
                    int i =  M11 < M22 ?
                            (M22 < M33 ? 2 : 1) :
                            (M11 < M33 ? 2 : 0);
                    int j = (i + 1) % 3;
                    int k = (i + 2) % 3;

                    double s = UnityEngine.Mathf.Sqrt(this[i,i] - this[j,j] - this[k,k] + 1.0f);
                    temp[i] = s * 0.5f;
                    s = 0.5f / s;

                    temp[3] = (this[j,k] - this[k,j]) * s;
                    temp[j] = (this[i,j] + this[j,i]) * s;
                    temp[k] = (this[i,k] + this[k,i]) * s;
                }
                return new BulletSharp.Math.Quaternion(temp[0], temp[1], temp[2], temp[3]);
                */

                //Scaling is the length of the rows.
                BulletSharp.Math.Vector3 scale;
                scale.X = (double)System.Math.Sqrt((bm.M11 * bm.M11) + (bm.M12 * bm.M12) + (bm.M13 * bm.M13));
                scale.Y = (double)System.Math.Sqrt((bm.M21 * bm.M21) + (bm.M22 * bm.M22) + (bm.M23 * bm.M23));
                scale.Z = (double)System.Math.Sqrt((bm.M31 * bm.M31) + (bm.M32 * bm.M32) + (bm.M33 * bm.M33));

                //The rotation is the left over matrix after dividing out the scaling.
                double mm11 = bm.M11 / scale.X;
                double mm12 = bm.M12 / scale.X;
                double mm13 = bm.M13 / scale.X;

                double mm21 = bm.M21 / scale.Y;
                double mm22 = bm.M22 / scale.Y;
                double mm23 = bm.M23 / scale.Y;

                double mm31 = bm.M31 / scale.Z;
                double mm32 = bm.M32 / scale.Z;
                double mm33 = bm.M33 / scale.Z;


                //------------------------
                double sqrt;
                double half;
                double trace = mm11 + mm22 + mm33;
                BulletSharp.Math.Quaternion result = new BulletSharp.Math.Quaternion();
                if (trace > 0.0f)
                {
                    sqrt = Math.Sqrt(trace + 1.0);
                    result.W = sqrt * 0.5f;
                    sqrt = 0.5f / sqrt;

                    result.X = (mm23 - mm32) * sqrt;
                    result.Y = (mm31 - mm13) * sqrt;
                    result.Z = (mm12 - mm21) * sqrt;
                }
                else if ((mm11 >= mm22) && (mm11 >= mm33))
                {
                    sqrt = Math.Sqrt(1.0 + mm11 - mm22 - mm33);
                    half = 0.5f / sqrt;

                    result.X = 0.5f * sqrt;
                    result.Y = (mm12 + mm21) * half;
                    result.Z = (mm13 + mm31) * half;
                    result.W = (mm23 - mm32) * half;
                }
                else if (mm22 > mm33)
                {
                    sqrt = Math.Sqrt(1.0 + mm22 - mm11 - mm33);
                    half = 0.5f / sqrt;

                    result.X = (mm21 + mm12) * half;
                    result.Y = 0.5f * sqrt;
                    result.Z = (mm32 + mm23) * half;
                    result.W = (mm31 - mm13) * half;
                }
                else
                {
                    sqrt = Math.Sqrt(1.0 + mm33 - mm11 - mm22);
                    half = 0.5f / sqrt;

                    result.X = (mm31 + mm13) * half;
                    result.Y = (mm32 + mm23) * half;
                    result.Z = 0.5f * sqrt;
                    result.W = (mm12 - mm21) * half;
                }
                //------------------------
                return result;
        }



        public static void SetOrientation(this BulletSharp.Math.Matrix bm, BulletSharp.Math.Quaternion q)
        {
                /*
                double d = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
                UnityEngine.Debug.Assert(d != 0.0f);
                double s = 2.0f / d;
                double xs = value.X * s, ys = value.Y * s, zs = value.Z * s;
                double wx = value.W * xs, wy = value.W * ys, wz = value.W * zs;
                double xx = value.X * xs, xy = value.X * ys, xz = value.X * zs;
                double yy = value.Y * ys, yz = value.Y * zs, zz = value.Z * zs;
                M11 = 1.0f - (yy + zz); M12 = xy - wz; M13 = xz + wy;
                M21 = xy + wz;   M22 = 1.0f - (xx + zz); M23 = yz - wx;
                M31 = xz - wy;   M32 = yz + wx; M33 = 1.0f - (xx + yy);
                */
                double xx = q.X * q.X;
                double yy = q.Y * q.Y;
                double zz = q.Z * q.Z;
                double xy = q.X * q.Y;
                double zw = q.Z * q.W;
                double zx = q.Z * q.X;
                double yw = q.Y * q.W;
                double yz = q.Y * q.Z;
                double xw = q.X * q.W;

                bm.M11 = 1.0f - (2.0f * (yy + zz));
                bm.M12 = 2.0f * (xy + zw);
                bm.M13 = 2.0f * (zx - yw);
                bm.M21 = 2.0f * (xy - zw);
                bm.M22 = 1.0f - (2.0f * (zz + xx));
                bm.M23 = 2.0f * (yz + xw);
                bm.M31 = 2.0f * (zx + yw);
                bm.M32 = 2.0f * (yz - xw);
                bm.M33 = 1.0f - (2.0f * (yy + xx));
        }

        public static BulletSharp.Math.Matrix ToBullet(this UnityEngine.Matrix4x4 um) {
            BulletSharp.Math.Matrix bm = new BulletSharp.Math.Matrix();
            um.ToBullet(ref bm);
            return bm;
        }

        public static void ToBullet(this UnityEngine.Matrix4x4 um, ref BulletSharp.Math.Matrix bm) {
            bm[0, 0] = um[0, 0];
            bm[0, 1] = um[1, 0];
            bm[0, 2] = um[2, 0];
            bm[0, 3] = um[3, 0];

            bm[1, 0] = um[0, 1];
            bm[1, 1] = um[1, 1];
            bm[1, 2] = um[2, 1];
            bm[1, 3] = um[3, 1];

            bm[2, 0] = um[0, 2];
            bm[2, 1] = um[1, 2];
            bm[2, 2] = um[2, 2];
            bm[2, 3] = um[3, 2];

            bm[3, 0] = um[0, 3];
            bm[3, 1] = um[1, 3];
            bm[3, 2] = um[2, 3];
            bm[3, 3] = um[3, 3];
        }

        public static void SetTransformationFromBulletMatrix(this UnityEngine.Transform transform, BulletSharp.Math.Matrix bm) {
            UnityEngine.Matrix4x4 matrix = bm.ToUnity();  //creates new Unity Matrix4x4
            transform.localPosition = ExtractTranslationFromMatrix(ref matrix);
            transform.localRotation = ExtractRotationFromMatrix(ref matrix);
            transform.localScale = ExtractScaleFromMatrix(ref matrix);
        }

        /// <summary>
        /// Extract translation from transform matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <returns>
        /// Translation offset.
        /// </returns>
        public static Vector3 ExtractTranslationFromMatrix(ref Matrix4x4 matrix) {
            Vector3 translate;
            translate.x = matrix.m03;
            translate.y = matrix.m13;
            translate.z = matrix.m23;
            return translate;
        }

        public static Vector3 ExtractTranslationFromMatrix(ref BulletSharp.Math.Matrix matrix) {
            Vector3 translate;
            translate.x = (float)matrix.M41;
            translate.y = (float)matrix.M42;
            translate.z = (float)matrix.M43;
            return translate;
        }

        /// <summary>
        /// Extract rotation quaternion from transform matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <returns>
        /// Quaternion representation of rotation transform.
        /// </returns>
        public static Quaternion ExtractRotationFromMatrix(ref Matrix4x4 matrix) {
            Vector3 forward;
            forward.x = matrix.m02;
            forward.y = matrix.m12;
            forward.z = matrix.m22;

            Vector3 upwards;
            upwards.x = matrix.m01;
            upwards.y = matrix.m11;
            upwards.z = matrix.m21;

            return Quaternion.LookRotation(forward, upwards);
        }

        public static Quaternion ExtractRotationFromMatrix(ref BulletSharp.Math.Matrix matrix) {
            Vector3 forward;
            forward.x = (float)matrix.M31;
            forward.y = (float)matrix.M32;
            forward.z = (float)matrix.M33;

            Vector3 upwards;
            upwards.x = (float)matrix.M21;
            upwards.y = (float)matrix.M22;
            upwards.z = (float)matrix.M23;

            return Quaternion.LookRotation(forward, upwards);
        }

        /// <summary>
        /// Extract scale from transform matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <returns>
        /// Scale vector.
        /// </returns>
        public static Vector3 ExtractScaleFromMatrix(ref Matrix4x4 matrix) {
            Vector3 scale;
            scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
            scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
            scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
            return scale;
        }

        public static Vector3 ExtractScaleFromMatrix(ref BulletSharp.Math.Matrix matrix) {
            Vector3 scale;
            scale.x = new Vector4((float)matrix.M11, (float)matrix.M12, (float)matrix.M13, (float)matrix.M14).magnitude;
            scale.y = new Vector4((float)matrix.M21, (float)matrix.M22, (float)matrix.M23, (float)matrix.M24).magnitude;
            scale.z = new Vector4((float)matrix.M31, (float)matrix.M32, (float)matrix.M33, (float)matrix.M34).magnitude;
            return scale;
        }

        /// <summary>
        /// Extract position, rotation and scale from TRS matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <param name="localPosition">Output position.</param>
        /// <param name="localRotation">Output rotation.</param>
        /// <param name="localScale">Output scale.</param>
        public static void DecomposeMatrix(ref Matrix4x4 matrix, out Vector3 localPosition, out Quaternion localRotation, out Vector3 localScale) {
            localPosition = ExtractTranslationFromMatrix(ref matrix);
            localRotation = ExtractRotationFromMatrix(ref matrix);
            localScale = ExtractScaleFromMatrix(ref matrix);
        }

        /// <summary>
        /// Set transform component from TRS matrix.
        /// </summary>
        /// <param name="transform">Transform component.</param>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        public static void SetTransformFromMatrix(Transform transform, ref Matrix4x4 matrix) {
            transform.localPosition = ExtractTranslationFromMatrix(ref matrix);
            transform.localRotation = ExtractRotationFromMatrix(ref matrix);
            transform.localScale = ExtractScaleFromMatrix(ref matrix);
        }


        // EXTRAS!

        /// <summary>
        /// Identity quaternion.
        /// </summary>
        /// <remarks>
        /// <para>It is faster to access this variation than <c>Quaternion.identity</c>.</para>
        /// </remarks>
        public static readonly Quaternion IdentityQuaternion = Quaternion.identity;
        /// <summary>
        /// Identity matrix.
        /// </summary>
        /// <remarks>
        /// <para>It is faster to access this variation than <c>Matrix4x4.identity</c>.</para>
        /// </remarks>
        public static readonly Matrix4x4 IdentityMatrix = Matrix4x4.identity;

        /// <summary>
        /// Get translation matrix.
        /// </summary>
        /// <param name="offset">Translation offset.</param>
        /// <returns>
        /// The translation transform matrix.
        /// </returns>
        public static Matrix4x4 TranslationMatrix(Vector3 offset) {
            Matrix4x4 matrix = IdentityMatrix;
            matrix.m03 = offset.x;
            matrix.m13 = offset.y;
            matrix.m23 = offset.z;
            return matrix;
        }
    }
}

