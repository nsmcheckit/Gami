using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GAMI 
{
    [AddComponentMenu("GAMI/DropdownSound")]
    public class DropdownSound : MonoBehaviour, IPointerClickHandler, ISelectHandler
    {
        public string[] openEvent;
        public string[] chooseEvent;
        public string[] closeEvent;
        private bool valueIsChanged = false;
        private bool isOpen = false;//dropdown是否展开

        void Start()
        {
            Dropdown dropdown = this.gameObject.GetComponent<Dropdown>();
            if (dropdown != null)
            {
                dropdown.onValueChanged.AddListener((int x) =>
                {
                    valueIsChanged = true;
                    PlaySound(chooseEvent);
                });
            }

        }

        public void OnPointerClick(PointerEventData eventData)
        {
#if UNITY_EDITOR
            SelectObject();
#endif
            PlayOpenSound();
        }

        public void OnSelect(BaseEventData eventData)
        {
            PlayCloseSound();
        }

        private void PlaySound(string[] events)
        {
            if (events == null) { return; }
            for (int i = 0; i < events.Length; ++i)
            {
                AudioManager.Instance.PlaySound2D(events[i]);
            }
        }

        private void PlayOpenSound()
        {
            if (!isOpen)
            {
                PlaySound(openEvent);
                isOpen = true;
            }
        }

        private void PlayCloseSound()
        {
            if (isOpen)
            {
                PlaySound(closeEvent);
                valueIsChanged = false;
                isOpen = false;
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
