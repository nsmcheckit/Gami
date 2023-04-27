using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GAMI.AnimationSound)), CanEditMultipleObjects]
public class AnimationSoundInspector : Editor
{
    GAMI.AnimationSound component;

    void OnEnable()
    {
        component = target as GAMI.AnimationSound;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //GUILayout.BeginHorizontal();
        //EditorGUILayout.LabelField("Is Update Position");
        //component.IsUpdatePosition = EditorGUILayout.Toggle(component.IsUpdatePosition);
        //EditorGUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Stop On Destroy");
        component.StopOnDestroy = EditorGUILayout.Toggle(component.StopOnDestroy);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Load Banks:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("Banks"));

        serializedObject.ApplyModifiedProperties();
    }
}

