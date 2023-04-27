using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAMI 
{
    /// <summary>
    /// 全局的声音对象，不会更新位置，用于2D声音播放,自己监听自己，不会监听别人
    /// 内部使用，不手动添加
    /// </summary>
    public class GlobalAudioGameObject : MonoBehaviour
    {
        void Awake()
        {
            AkSoundEngine.RegisterGameObj(gameObject, "GlobalAudioGameObject2D");
            AkSoundEngine.SetListeners(gameObject, new ulong[] { AkSoundEngine.GetAkGameObjectID(gameObject) }, 1);                                                                                             
            DontDestroyOnLoad(gameObject);
        }

        void Destroy()
        {
            if (AkSoundEngine.IsInitialized())
            {
                AkSoundEngine.RemoveListener(gameObject, gameObject);
                AkSoundEngine.UnregisterGameObj(gameObject);
                GAMI.AudioManager.Instance.UnRegisterALLGoId();
            }
        }

        void Update()
        {
            AudioManager.Instance.Refresh3DListener();
        }

    }
}

