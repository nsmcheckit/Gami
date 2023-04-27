using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GAMI 
{

    [RequireComponent(typeof(GAMI.AudioGameObject))]
    public class AudioListener : MonoBehaviour
    {

        private void Awake()
        {
            AudioManager.Instance.Set3DListener(gameObject);
        }

        private void OnDestroy()
        {
            AudioManager.Instance.Remove3DListener(gameObject);
        }


        // ensure the AudioGameObject component attach in gameobj,see [RequireComponent(typeof(GAMI.AudioGameObject))]
        public Vector3 GetPosition() 
        {
            return gameObject.GetComponent<AudioGameObject>().GetPosition();
        }

        public Vector3 GetForward() 
        {
            return gameObject.GetComponent<AudioGameObject>().GetForward();
        }


        public Vector3 GetUp() 
        {
            return gameObject.GetComponent<AudioGameObject>().GetUpward();
        }


        public void SetPositionOverride(Transform overridePosition_Transform)
        {
            AudioGameObject aGo = gameObject.GetComponent<AudioGameObject>();
            if (aGo != null && overridePosition_Transform != null)
            {
                aGo.overridePosition = true;
                aGo.OverridePosition_Transform = overridePosition_Transform;
            }
        }

        public void SetFowardUpOverride(Transform overrideFowardUp_Transform) 
        {
            AudioGameObject aGo = gameObject.GetComponent<AudioGameObject>();
            if (aGo != null && overrideFowardUp_Transform != null)
            {
                aGo.overrideFowardUp = true;
                aGo.OverrideFowardUp_Transform = overrideFowardUp_Transform;
            }

        }

        public void ResetPositionOverride() 
        {
            AudioGameObject aGo = gameObject.GetComponent<AudioGameObject>();
            if (aGo != null)
            {
                aGo.overridePosition = false;
                aGo.OverridePosition_Transform = null;
            }
        }

        public void ResetFowardUpOverride()
        {
            AudioGameObject aGo = gameObject.GetComponent<AudioGameObject>();
            if (aGo != null)
            {
                aGo.overridePosition = false;
                aGo.OverrideFowardUp_Transform = null;
            }
        }



    }






}

