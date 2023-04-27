using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GAMI.EffectSound)), CanEditMultipleObjects]
public class EffectSoundInspector : Editor
{
    GAMI.EffectSound component;

    void OnEnable()
    {
        component = target as GAMI.EffectSound;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Enable Trigger Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("enableEvents"));
        EditorGUILayout.LabelField("Disable Trigger Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("disableEvents"));
        serializedObject.ApplyModifiedProperties();
    }
}