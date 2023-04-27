using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(GAMI.ButtonSound)), CanEditMultipleObjects]
public class ButtonSoundInspector : Editor
{
    GAMI.ButtonSound component;

    void OnEnable()
    {
        component = target as GAMI.ButtonSound;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("OnClick Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("audioEvents"));
        EditorGUILayout.LabelField("Mouse In Event:");
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mouseinEvent"), GUIContent.none);
        serializedObject.ApplyModifiedProperties();
        Check();
    }

    void Check()
    {
        if (component.GetComponent<Button>() == null)
        { 
            EditorGUILayout.HelpBox("Can't Find Button Component !", UnityEditor.MessageType.Error);
        }
    }
}