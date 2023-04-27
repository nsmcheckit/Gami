using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GAMI.AudioGameObject))]
public class AudioGameObjectInspector : Editor
{
    private GAMI.AudioGameObject audioGameObject;


    private void Awake()
    {
        audioGameObject = (GAMI.AudioGameObject)target;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();
        SerializedProperty isStaticObject = serializedObject.FindProperty("isStaticObject");
        EditorGUILayout.PropertyField(isStaticObject,new GUIContent("Is Static Object", "固定的点声源环境声，勾选这个"));
        if (audioGameObject.gameObject.isStatic != isStaticObject.boolValue)
            audioGameObject.gameObject.isStatic = isStaticObject.boolValue;

        if (audioGameObject.enabled == audioGameObject.gameObject.isStatic)
            audioGameObject.enabled = !audioGameObject.gameObject.isStatic;

        audioGameObject.isEnvironmentAware = EditorGUILayout.Toggle("Is Environment Aware", audioGameObject.isEnvironmentAware);
 
        audioGameObject.overridePosition = EditorGUILayout.Toggle("Override Position", audioGameObject.overridePosition);
        if (audioGameObject.overridePosition)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("t_overridePosition_Transform"), new GUIContent("OverridePosition_Transform"));
        }
        audioGameObject.overrideFowardUp = EditorGUILayout.Toggle("Override Foward Up", audioGameObject.overrideFowardUp);
        if (audioGameObject.overrideFowardUp)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("t_overrideFowardUp_Transform"), new GUIContent("OverrideFowardUp_Transform"));
        }
        serializedObject.ApplyModifiedProperties();
    }


    


}