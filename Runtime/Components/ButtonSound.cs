using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GAMI
{
    /// <summary>
    /// Button���ʱ����audioEvent
    /// </summary>
    [AddComponentMenu("GAMI/ButtonSound")]
    public class ButtonSound : MonoBehaviour
    {
        public string[] audioEvents;
        public string mouseinEvent;

        void Start()
        {
            Button button = GetComponent<Button>();
            if (button != null && button.onClick != null)
            {
                button.onClick.AddListener(() => 
                {
#if UNITY_EDITOR
                    SelectObject();
#endif
                    PlaySound();
                });
                EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
                if (trigger != null)
                {
                    EventTrigger.Entry entry = new EventTrigger.Entry();
                    entry.eventID = EventTriggerType.PointerEnter;
                    entry.callback = new EventTrigger.TriggerEvent();
                    entry.callback.AddListener(OnPointEnter);
                    trigger.triggers.Add(entry);
                }
            }

        }

        public void PlaySound()
        {
            if(AkSoundEngine.IsInitialized())
            {
                for (int i = 0; i < audioEvents.Length; ++i)
                {
                    AudioManager.Instance.PlaySound2D(audioEvents[i]);
                }
            }
        }

        public void OnPointEnter(BaseEventData pointData)
        {
            if (AkSoundEngine.IsInitialized() && mouseinEvent != null)
            {
                AudioManager.Instance.PlaySound2D(mouseinEvent);
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

