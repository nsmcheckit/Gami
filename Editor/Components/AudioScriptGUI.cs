using UnityEditor;
using UnityEngine;

public class AudioScriptGUI
{
    private static GUIContent deleteButtonContent = new GUIContent("x", "delete"), addButtonContent = new GUIContent("+", "add element");

    private static GUILayoutOption miniButtonWidth = GUILayout.Width(30f);

    public static void DrawList(SerializedProperty propertyList)
    {
        if (!propertyList.isArray)
        {
            EditorGUILayout.HelpBox(propertyList.name + " is neither an array nor a list!", MessageType.Error);
            return;
        }

        SerializedProperty size = propertyList.FindPropertyRelative("Array.size");
        if (size.hasMultipleDifferentValues)
        {
            EditorGUILayout.HelpBox("Not showing lists with different sizes.", MessageType.Info);
        }

        using (var vs = new EditorGUILayout.VerticalScope("box"))
        {
            EditorGUILayout.BeginVertical();
            for (int i = 0; i < propertyList.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.PropertyField(propertyList.GetArrayElementAtIndex(i), GUIContent.none);

                DrawListDeleteButtons(propertyList, i);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Separator();
            }
            if (GUILayout.Button(addButtonContent, EditorStyles.miniButton))
            {
                propertyList.arraySize += 1;
            }
            EditorGUILayout.EndVertical();
        }
    }

    private static void DrawListDeleteButtons(SerializedProperty propertyList, int index)
    {
        GUI.backgroundColor = Color.cyan;
        if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth))
        {
            int oldSize = propertyList.arraySize;
            propertyList.DeleteArrayElementAtIndex(index);
            if (propertyList.arraySize == oldSize)
            {
                propertyList.DeleteArrayElementAtIndex(index);
            }
        }
        GUI.backgroundColor = Color.white;
    }
}