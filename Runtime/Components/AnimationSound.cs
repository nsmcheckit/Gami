using System.Numerics;
using UnityEngine;

namespace GAMI
{
    /// <summary>
    /// ������Ч��ʵʱ����3Dλ������
    /// </summary>
    [AddComponentMenu("GAMI/AnimationSound")]
    [DisallowMultipleComponent]
    public class AnimationSound : MonoBehaviour
    {
        public string[] Banks;

        public bool StopOnDestroy = true;



        void Awake()
        {
            LoadBanks();           
        }
       
        void OnDestroy()
        {
            if (StopOnDestroy)
            {
                if (AkSoundEngine.IsInitialized()) 
                {
                    AkSoundEngine.StopAll(gameObject);
                }
            }
            UnloadBanks();
        }

        //for animator
        public void PlaySound(string eventName)
        {
            if(AkSoundEngine.IsInitialized())
            {
                AudioManager.Instance.PlaySound(eventName, gameObject);
            }
        }

        public void StopSound(string eventName)
        {
            if(AkSoundEngine.IsInitialized())
            {
                AudioManager.Instance.StopSound(eventName, gameObject);
            }
        }

        //for timeline playableasset
        public void Play(AK.Wwise.Event events)
        {
            if(AkSoundEngine.IsInitialized())
            {
                events.Post(gameObject);
            }
        }

        public void Stop(AK.Wwise.Event events)
        {
            if(AkSoundEngine.IsInitialized())
            {
                events.Stop(gameObject, 0, AkCurveInterpolation.AkCurveInterpolation_Linear);
            }
        }

        void LoadBanks()
        {
            if (Banks != null)
            {
                for (var i = 0; i < Banks.Length; ++i)
                {
                    AkBankManager.LoadBank(Banks[i], false, false);
                }
            }
            
        }


        void UnloadBanks()
        {
            if (Banks != null)
            {
                for (var i = 0; i < Banks.Length; ++i)
                {
                    AkBankManager.UnloadBank(Banks[i]);
                }
            }
        }
    }
}