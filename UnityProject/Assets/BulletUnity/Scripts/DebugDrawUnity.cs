using System;
using System.Collections;
using BulletSharp;
using BM = BulletSharp.Math;

namespace BulletUnity
{
    public class DebugDrawUnity : DebugDraw
    {
        public override void DrawLine(ref BM.Vector3 from, ref BM.Vector3 to, ref BM.Vector3 fromColor) {
            UnityEngine.Gizmos.color = new UnityEngine.Color((float)fromColor.X, (float)fromColor.Y, (float)fromColor.Z);
            UnityEngine.Gizmos.DrawLine(from.ToUnity(), to.ToUnity());
        }
        public override void DrawLine(ref BM.Vector3 from, ref BM.Vector3 to, ref BM.Vector3 fromColor, ref BM.Vector3 toColor) {
            UnityEngine.Gizmos.color = new UnityEngine.Color((float)fromColor.X, (float)fromColor.Y, (float)fromColor.Z);
            UnityEngine.Gizmos.DrawLine(from.ToUnity(), to.ToUnity());
        }
        public override void DrawBox(ref BM.Vector3 bbMin, ref BM.Vector3 bbMax, ref BM.Vector3 color) {
            UnityEngine.Bounds b = new UnityEngine.Bounds(bbMin.ToUnity(), UnityEngine.Vector3.zero);
            b.Encapsulate(bbMax.ToUnity());
            UnityEngine.Gizmos.color = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            UnityEngine.Gizmos.DrawWireCube(b.center,b.size);
        }

        public override void DrawBox(ref BM.Vector3 bbMin, ref BM.Vector3 bbMax, ref BM.Matrix trans, ref BM.Vector3 color) {
            UnityEngine.Vector3 pos = BSExtensionMethods2.ExtractTranslationFromMatrix(ref trans);
            UnityEngine.Quaternion rot = BSExtensionMethods2.ExtractRotationFromMatrix(ref trans);
            UnityEngine.Vector3 scale = BSExtensionMethods2.ExtractScaleFromMatrix(ref trans);
            UnityEngine.Vector3 size = (bbMax - bbMin).ToUnity();
            UnityEngine.Color c = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawBox(pos, rot, scale, size,c);
        }
        public override void DrawSphere(ref BM.Vector3 p, double radius, ref BM.Vector3 color) {
            UnityEngine.Color c = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawSphere(p.ToUnity(),UnityEngine.Quaternion.identity,UnityEngine.Vector3.one, UnityEngine.Vector3.one * (float)radius, c);
        }

        public override void DrawSphere(double radius, ref BM.Matrix trans, ref BM.Vector3 color) {
            UnityEngine.Vector3 pos = BSExtensionMethods2.ExtractTranslationFromMatrix(ref trans);
            UnityEngine.Quaternion rot = BSExtensionMethods2.ExtractRotationFromMatrix(ref trans);
            UnityEngine.Vector3 scale = BSExtensionMethods2.ExtractScaleFromMatrix(ref trans);
            UnityEngine.Color c = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawSphere(pos, rot, scale, UnityEngine.Vector3.one * (float)radius, c);
        }

        public override void DrawTriangle(ref BM.Vector3 v0, ref BM.Vector3 v1, ref BM.Vector3 v2, ref BM.Vector3 n0, ref BM.Vector3 n1, ref BM.Vector3 n2, ref BM.Vector3 color, double alpha) {
            //todo normals and alpha
            UnityEngine.Gizmos.color = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            UnityEngine.Gizmos.DrawLine(v0.ToUnity(), v1.ToUnity());
            UnityEngine.Gizmos.DrawLine(v1.ToUnity(), v2.ToUnity());
            UnityEngine.Gizmos.DrawLine(v2.ToUnity(), v0.ToUnity());
        }
        public override void DrawTriangle(ref BM.Vector3 v0, ref BM.Vector3 v1, ref BM.Vector3 v2, ref BM.Vector3 color, double alpha) {
            UnityEngine.Gizmos.color = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            UnityEngine.Gizmos.DrawLine(v0.ToUnity(), v1.ToUnity());
            UnityEngine.Gizmos.DrawLine(v1.ToUnity(), v2.ToUnity());
            UnityEngine.Gizmos.DrawLine(v2.ToUnity(), v0.ToUnity());
        }
        public override void DrawContactPoint(ref BM.Vector3 pointOnB, ref BM.Vector3 normalOnB, double distance, int lifeTime, ref BM.Vector3 color) {
            UnityEngine.Gizmos.color = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            UnityEngine.Gizmos.DrawWireSphere(pointOnB.ToUnity(), .2f);
        }
        public override void ReportErrorWarning(String warningString) {
            UnityEngine.Debug.LogError(warningString);
        }
        public override void Draw3dText(ref BM.Vector3 location, String textString) {
            UnityEngine.Debug.LogError("Not implemented");
        }
        
        DebugDrawModes _debugMode;
        public override DebugDrawModes DebugMode {
            get { return _debugMode; }
            set { _debugMode = value; }
        }

        public override void DrawAabb(ref BM.Vector3 from, ref BM.Vector3 to, ref BM.Vector3 color) {
            DrawBox(ref from, ref to, ref color);
        }
        public override void DrawTransform(ref BM.Matrix trans, double orthoLen) {
            UnityEngine.Vector3 pos = BSExtensionMethods2.ExtractTranslationFromMatrix(ref trans);
            UnityEngine.Quaternion rot = BSExtensionMethods2.ExtractRotationFromMatrix(ref trans);
            UnityEngine.Vector3 p1 = pos + rot * UnityEngine.Vector3.up * (float)orthoLen;
            UnityEngine.Vector3 p2 = pos - rot * UnityEngine.Vector3.up * (float)orthoLen;
            UnityEngine.Gizmos.DrawLine(p1, p2);
            p1 = pos + rot * UnityEngine.Vector3.right * (float)orthoLen;
            p2 = pos - rot * UnityEngine.Vector3.right * (float)orthoLen;
            UnityEngine.Gizmos.DrawLine(p1, p2);
            p1 = pos + rot * UnityEngine.Vector3.forward * (float)orthoLen;
            p2 = pos - rot * UnityEngine.Vector3.forward * (float)orthoLen;
            UnityEngine.Gizmos.DrawLine(p1, p2);
        }
        public override void DrawArc(ref BM.Vector3 center, ref BM.Vector3 normal, ref BM.Vector3 axis, double radiusA, double radiusB, double minAngle, double maxAngle,
            ref BM.Vector3 color, bool drawSect)
        {
            UnityEngine.Debug.LogError("Not implemented");
        }
        public override void DrawArc(ref BM.Vector3 center, ref BM.Vector3 normal, ref BM.Vector3 axis, double radiusA, double radiusB, double minAngle, double maxAngle,
            ref BM.Vector3 color, bool drawSect, double stepDegrees)
        {
            UnityEngine.Color col = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawArc(center.ToUnity(), normal.ToUnity(), axis.ToUnity(), (float)radiusA, (float)radiusB, (float)minAngle, (float)maxAngle, col, drawSect, (float)stepDegrees);
        }
        public override void DrawSpherePatch(ref BM.Vector3 center, ref BM.Vector3 up, ref BM.Vector3 axis, double radius,
            double minTh, double maxTh, double minPs, double maxPs, ref BM.Vector3 color)
        {
            UnityEngine.Debug.LogError("Not implemented");
            
        }
        public override void DrawSpherePatch(ref BM.Vector3 center, ref BM.Vector3 up, ref BM.Vector3 axis, double radius,
            double minTh, double maxTh, double minPs, double maxPs, ref BM.Vector3 color, double stepDegrees)
        {
            UnityEngine.Debug.LogError("Not implemented");
        }
        public override void DrawCapsule(double radius, double halfHeight, int upAxis, ref BM.Matrix trans, ref BM.Vector3 color) {
            UnityEngine.Vector3 pos = BSExtensionMethods2.ExtractTranslationFromMatrix(ref trans);
            UnityEngine.Quaternion rot = BSExtensionMethods2.ExtractRotationFromMatrix(ref trans);
            UnityEngine.Vector3 scale = BSExtensionMethods2.ExtractScaleFromMatrix(ref trans);
            UnityEngine.Color c = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawCapsule(pos, rot, scale, (float)radius, (float)halfHeight, upAxis, c);
        }
        public override void DrawCylinder(double radius, double halfHeight, int upAxis, ref BM.Matrix trans, ref BM.Vector3 color) {
            UnityEngine.Vector3 pos = BSExtensionMethods2.ExtractTranslationFromMatrix(ref trans);
            UnityEngine.Quaternion rot = BSExtensionMethods2.ExtractRotationFromMatrix(ref trans);
            UnityEngine.Vector3 scale = BSExtensionMethods2.ExtractScaleFromMatrix(ref trans);
            UnityEngine.Color c = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawCylinder(pos,rot,scale, (float)radius, (float)halfHeight,upAxis, c);
        }
        public override void DrawCone(double radius, double height, int upAxis, ref BM.Matrix trans, ref BM.Vector3 color) {
            UnityEngine.Vector3 pos = BSExtensionMethods2.ExtractTranslationFromMatrix(ref trans);
            UnityEngine.Quaternion rot = BSExtensionMethods2.ExtractRotationFromMatrix(ref trans);
            UnityEngine.Vector3 scale = BSExtensionMethods2.ExtractScaleFromMatrix(ref trans);
            UnityEngine.Color c = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawCone(pos, rot, scale, (float)radius, (float)height, upAxis, c);
        }
        public override void DrawPlane(ref BM.Vector3 planeNormal, double planeConst, ref BM.Matrix trans, ref BM.Vector3 color) {
            UnityEngine.Vector3 pos = BSExtensionMethods2.ExtractTranslationFromMatrix(ref trans);
            UnityEngine.Quaternion rot = BSExtensionMethods2.ExtractRotationFromMatrix(ref trans);
            UnityEngine.Vector3 scale = BSExtensionMethods2.ExtractScaleFromMatrix(ref trans);
            UnityEngine.Color c = new UnityEngine.Color((float)color.X, (float)color.Y, (float)color.Z);
            BUtility.DebugDrawPlane(pos, rot, scale, planeNormal.ToUnity(), (float)planeConst, c);
        }
    }
}
