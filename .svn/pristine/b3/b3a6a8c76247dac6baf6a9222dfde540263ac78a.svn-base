using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAMI
{
    [Serializable]
    public class SoundParam
    {
        public string audioEvent;
        public bool soundIs2D = false;//2D用GlobalAudioGameObject播，不更新position
        public bool stopOnDestroy = false;
        [Range(0, 8)]
        public float fadeOutTime = 1.0f;
    }


    [System.Serializable]
    public class WwisePositionTemplate
    {
        public Vector3 position;
        public Vector3 rotation;

        public WwisePositionTemplate(Vector3 p, Vector3 r)
        {
            position = p;
            rotation = r;
        }

    }

    [System.Serializable]
    public class SoundState
    {
        public string stateGroup;
        public string state;
    }

}

