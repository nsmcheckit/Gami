
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GAMI
{
    /// <summary>
    /// Toggle���ʱ����audioEvent
    /// </summary>
    [AddComponentMenu("GAMI/ToggleSound")]
    public class ToggleSound : MonoBehaviour
    {
        public string[] toggleaudioEvents;
        public string[] untoggleaudioEvents;

        void Start()
        {
            Toggle toggle = GetComponent<Toggle>();
            if (toggle != null)
            {
                toggle.onValueChanged.AddListener((isOnChange) =>
                {
#if UNITY_EDITOR
                    SelectObject();
#endif
                    if (!toggle.isOn)
                    {
                        PlaySound(toggleaudioEvents);
                    }
                    else
                    {
                        PlaySound(untoggleaudioEvents);
                    }
                });
            }
        }

        public void PlaySound(string[] events)
        {
            if (events == null) { return; }
            if (AkSoundEngine.IsInitialized())
            {
                for (int i = 0; i < events.Length; ++i)
                {
                    AudioManager.Instance.PlaySound2D(events[i]);
                }
            }
        }


#if UNITY_EDITOR
        public void SelectObject()
        {
            EditorGUIUtility.PingObject(gameObject);
            Selection.activeObject = gameObject;
        }
#endif





    }
}
