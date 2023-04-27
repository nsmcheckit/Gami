using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAMI 
{
    [RequireComponent(typeof(GAMI.AudioGameObject))]
    [DisallowMultipleComponent()]
    [AddComponentMenu("GAMI/AmbientSound")]
    public class AmbientSound : MonoBehaviour
    {
        [Header("Wwise:")]
        public string soundEvent;
        public AkMultiPositionType positionType = AkMultiPositionType.MultiPositionType_MultiDirections;
        public uint playingId = AkSoundEngine.AK_INVALID_PLAYING_ID;

        public List<WwisePositionTemplate> positionList = new List<WwisePositionTemplate>();
        

        private void OnEnable()
        {
            if (positionType != AkMultiPositionType.MultiPositionType_SingleSource)
            {
                var positionArray = BuildAkPositionArray();
                AkSoundEngine.SetMultiplePositions(gameObject, positionArray, (ushort)positionList.Count, positionType);
            }
            playingId = PlayAmbientSound();
        }

        void Start()
        {
            
        }

        private void OnDisable()
        {
            StopAmbientSound();
        }


        private void OnDestroy()
        {

        }

        public uint PlayAmbientSound()
        {
            uint playingId = AkSoundEngine.AK_INVALID_PLAYING_ID;
            if (AkSoundEngine.IsInitialized())
            {
                if (!string.IsNullOrEmpty(soundEvent))
                {
                    playingId = AkSoundEngine.PostEvent(soundEvent, gameObject);
                }               
            }
            return playingId;
        }

        public void StopAmbientSound()
        {
            if (AkSoundEngine.IsInitialized())
            {
                if (playingId != AkSoundEngine.AK_INVALID_PLAYING_ID)
                {
                    AkSoundEngine.StopPlayingID(playingId, 1000);
                }
            }

        }


        /// <summary>
        /// ���ɶ��λ������
        /// </summary>
        /// <returns></returns>
        private AkPositionArray BuildAkPositionArray()
        {
            AkPositionArray playPostionArr = new AkPositionArray((uint)positionList.Count);
            for (int i = 0; i < positionList.Count; ++i)
            {
                playPostionArr.Add(positionList[i].position+transform.position,
                    Quaternion.Euler(positionList[i].rotation) * Vector3.forward,
                    Quaternion.Euler(positionList[i].rotation) * Vector3.up);
            }
            return playPostionArr;
        }


    }
}
