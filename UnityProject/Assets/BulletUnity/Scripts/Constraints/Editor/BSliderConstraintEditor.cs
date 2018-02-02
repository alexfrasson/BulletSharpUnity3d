using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using BulletUnity;

[CustomEditor(typeof(BSliderConstraint))]
public class BSliderConstraintEditor : Editor {

    public override void OnInspectorGUI() {
        BSliderConstraint hc = (BSliderConstraint)target;
        EditorGUILayout.HelpBox(BSliderConstraint.HelpMessage, MessageType.Info);

        BTypedConstraintEditor.DrawTypedConstraint(hc);

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Limits", EditorStyles.boldLabel);
        hc.lowerLinearLimit = EditorGUILayout.FloatField("Lower Linear Limit", (float)hc.lowerLinearLimit);
        hc.upperLinearLimit = EditorGUILayout.FloatField("Upper Linear Limit", (float)hc.upperLinearLimit);

        hc.lowerAngularLimitRadians = EditorGUILayout.FloatField("Lower Angular Limit (Deg.)", (float)hc.lowerAngularLimitRadians * Mathf.Rad2Deg) * Mathf.Deg2Rad;
        hc.upperAngularLimitRadians = EditorGUILayout.FloatField("Upper Angular Limit (Deg.)", (float)hc.upperAngularLimitRadians * Mathf.Rad2Deg) * Mathf.Deg2Rad;

        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(hc);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            Repaint();
        }
    }
}
