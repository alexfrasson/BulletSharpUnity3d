using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using BulletUnity;

[CustomEditor(typeof(BHingedConstraint))]
public class BHingedConstraintEditor : Editor {



    public override void OnInspectorGUI() {
        BHingedConstraint hc = (BHingedConstraint)target;
        EditorGUILayout.HelpBox(BHingedConstraint.HelpMessage, MessageType.Info);
        EditorGUILayout.LabelField("Hinge Angle (Deg.)" + hc.GetAngle() * Mathf.Rad2Deg);
        BTypedConstraintEditor.DrawTypedConstraint(hc);

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Motor", EditorStyles.boldLabel);
        hc.enableMotor = EditorGUILayout.Toggle("Enable Motor",hc.enableMotor);
        hc.targetMotorAngularVelocity = EditorGUILayout.FloatField("Target Motor Angular Velocity (Rad/Sec)", (float)hc.targetMotorAngularVelocity);
        hc.maxMotorImpulse = EditorGUILayout.FloatField("Max Motor Impulse", (float)hc.maxMotorImpulse);

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Limits", EditorStyles.boldLabel);
        hc.setLimit = EditorGUILayout.Toggle("Set Limit", hc.setLimit);
        hc.lowLimitAngleRadians = EditorGUILayout.FloatField("Low Angle (Deg.)", (float)hc.lowLimitAngleRadians * Mathf.Rad2Deg) * Mathf.Deg2Rad;
        hc.highLimitAngleRadians = EditorGUILayout.FloatField("High Angle (Deg.)", (float)hc.highLimitAngleRadians * Mathf.Rad2Deg) * Mathf.Deg2Rad;
        hc.limitSoftness = EditorGUILayout.FloatField("Limit Softness", (float)hc.limitSoftness);
        hc.limitBiasFactor = EditorGUILayout.FloatField("Limit Bias Factor", (float)hc.limitBiasFactor);
        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(hc);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            Repaint();
        }
    }
}
