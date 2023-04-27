using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GAMI
{
    /// <summary>
    /// 用于设置rtpc
    /// </summary>
    [AddComponentMenu("GAMI/SliderSound")]
    public class SliderSound : MonoBehaviour, IPointerUpHandler
    {
        public string RTPCName;
        public string[] incAudioEvents;
        public string[] decAudioEvents;
        public string[] pointerUpAudioEvents;
        private float currentValue;
        void Start()
        {
            Slider s = this.gameObject.GetComponent<Slider>();
            if (s != null)
            {
                s.onValueChanged.AddListener(x =>
                {
                    if (!string.IsNullOrEmpty(RTPCName)) { AkSoundEngine.SetRTPCValue(RTPCName, x); }
                    if (x > currentValue) { PlaySound(incAudioEvents); }
                    else if (x < currentValue) { PlaySound(decAudioEvents); }                    
                    currentValue = x;               
                });
            }
        }
        void PlaySound(string[] events)
        {
            if (events == null) { return; }
            if (AkSoundEngine.IsInitialized())
            {               
                for (int i = 0; i < events.Length; i++)
                {
                    AudioManager.Instance.PlaySound2D(events[i]);
                }
            }
        }

        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
#if UNITY_EDITOR
            SelectObject();
#endif
            PlaySound(pointerUpAudioEvents);
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

