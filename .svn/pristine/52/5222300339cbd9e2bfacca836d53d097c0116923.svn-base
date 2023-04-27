using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GAMI.LoadBanks)),CanEditMultipleObjects]
public class LoadBanksInspector : Editor
{
    GAMI.LoadBanks loadBanks;



    private void OnEnable()
    {
        loadBanks = (GAMI.LoadBanks)target;
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Sound Banks To Load:");

        SerializedProperty prop = serializedObject.FindProperty("banksToLoad");
        AudioScriptGUI.DrawList(prop);

        serializedObject.ApplyModifiedProperties();
    }




}
