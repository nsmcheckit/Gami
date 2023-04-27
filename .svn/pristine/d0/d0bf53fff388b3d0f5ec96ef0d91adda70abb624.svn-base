using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(GAMI.DropdownSound)), CanEditMultipleObjects]
public class DropdownSoundInspector : Editor
{
    private GAMI.DropdownSound component;

    void OnEnable()
    {
        component = target as GAMI.DropdownSound;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Open Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("openEvent"));
        EditorGUILayout.LabelField("Choose Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("chooseEvent"));
        EditorGUILayout.LabelField("Close Events:");
        AudioScriptGUI.DrawList(serializedObject.FindProperty("closeEvent"));
        serializedObject.ApplyModifiedProperties();
        Check();
    }

    void Check()
    {
        if (component.GetComponent<Dropdown>() == null)
        {
            EditorGUILayout.HelpBox("Can't Find Dropdown Component !", UnityEditor.MessageType.Error);
        }
    }



}
