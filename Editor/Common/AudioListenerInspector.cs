using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GAMI.AudioListener))]
public class AudioListenerInspector : Editor
{
    private GAMI.AudioListener audioListener;

    private void OnEnable()
    {
        audioListener = this.target as GAMI.AudioListener;
    }

    public override void OnInspectorGUI() 
    {
        //audioListener.isDefaultListener = EditorGUILayout.Toggle("IsDefaultAudioListener", audioListener.isDefaultListener);
    }
}
