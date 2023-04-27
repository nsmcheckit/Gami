using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GAMI.SliderSound)), CanEditMultipleObjects]
public class SliderSoundInspector : Editor
{
    GAMI.SliderSound component;

    void OnEnable()
    {
        component = target as GAMI.SliderSound;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("RTPCName"));
        EditorGUILayout.LabelField("Value Inc Audio Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("incAudioEvents"));
        EditorGUILayout.LabelField("Value Dec Audio Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("decAudioEvents"));
        EditorGUILayout.LabelField("Pointer Up Audio Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("pointerUpAudioEvents"));
        serializedObject.ApplyModifiedProperties();
    }
}