using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(GAMI.ToggleSound)), CanEditMultipleObjects]
public class ToggleSoundInspector : Editor
{
    GAMI.ToggleSound component;

    void OnEnable()
    {
        component = target as GAMI.ToggleSound;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Toggle Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("toggleaudioEvents"));

        EditorGUILayout.LabelField("UnToggle Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("untoggleaudioEvents"));
        serializedObject.ApplyModifiedProperties();
        Check();
    }

    void Check()
    {
        if(component.GetComponent<Toggle>() == null)
        {
            EditorGUILayout.HelpBox("Can't Find Toggle Component !", UnityEditor.MessageType.Error);
        }
    }
}