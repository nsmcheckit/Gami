using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace GAMI
{

    public sealed class AudioManager
    {
        #region Singleton
        private static readonly AudioManager instance = new AudioManager();

        static AudioManager()
        {
        }

        private AudioManager()
        {
        }

        public static AudioManager Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        private GameObject globalAudioGameObject;//2d全局物体也是2d声音listener，用于初始化及播放音乐、UI等2d声音
        public GameObject GlobalAudioGameObject 
        {
            get { return globalAudioGameObject; }       
        }

        private GameObject default3DAudioListener;//默认的 3D AudioListener

        public GameObject Default3DAudioListener 
        {
            get { return default3DAudioListener; }       
        }

        public bool isInited = false;


        public void Init(bool SetMainCameraIsDefault3DListener = true)
        {
            if (!isInited)
            {
                globalAudioGameObject = new GameObject("AudioManager");
                //AkInitializer initializer = globalAudioGameObject.AddComponent<AkInitializer>();//注释掉，改为在场景中添加
                
                globalAudioGameObject.AddComponent<GlobalAudioGameObject>();
                
                if (SetMainCameraIsDefault3DListener && Camera.main != null)
                {
                    Camera.main.gameObject.AddComponent<AudioListener>();
                }
                isInited = true;
                
            }
        }



        //void Callback(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
        //{
        //    switch (in_type)
        //    {
        //        case AkCallbackType.AK_EndOfEvent:
        //            if (in_cookie != null)
        //            {
        //                AudioCtrl.EventCallback cb = (AudioCtrl.EventCallback)in_cookie;
        //                cb();
        //            }
        //            break;
        //        case AkCallbackType.AK_Marker:
        //            AkMarkerCallbackInfo info = in_info as AkMarkerCallbackInfo;
        //            AkSoundEngine.Log(info.strLabel);
        //            break;
        //        default:
        //            //AkSoundEngine.LogError("Callback Type not march.");
        //            break;
        //    }
        //}

        public uint PlaySound(string eventName, GameObject gameObj)
        {
            uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;
            if (!string.IsNullOrEmpty(eventName))
            {
                playingID = AkSoundEngine.PostEvent(eventName, gameObj);
            }
            return playingID;
        }

        public uint PlaySound(uint eventID, GameObject gameObj)
        {
            uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;
            if (eventID != 0)
            {
                playingID = AkSoundEngine.PostEvent(eventID, gameObj);
            }
            return playingID;
        }

        public uint PlaySound2D(string eventName)
        {
            uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;
            if (!string.IsNullOrEmpty(eventName))
            {
                playingID = AkSoundEngine.PostEvent(eventName, globalAudioGameObject);
            }
            return playingID;
        }
        public uint PlaySound2D(uint eventId)
        {
            uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;
            if (eventId != 0)
            {
                playingID = AkSoundEngine.PostEvent(eventId, globalAudioGameObject);
            }
            return playingID;
        }
        //public uint PlaySound(string eventName,AudioCtrl.EventCallback cb)
        //{
        //    uint playingID = AkSoundEngine.AK_INVALID_PLAYING_ID;
        //    if (!string.IsNullOrEmpty(eventName))
        //        playingID = AkSoundEngine.PostEvent(eventName, GlobalSoundObject, (uint)AkCallbackType.AK_EndOfEvent, Callback, cb);
        //    return playingID;
        //}

        public AKRESULT StopSound(string eventName, GameObject gameObj, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                if (gameObj != null)
                {
                    return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Stop,
                                    gameObj, transitionDuration, curveInterpolation);
                }
            }
            return AKRESULT.AK_Fail;
        }

        public AKRESULT StopSound(uint eventID, GameObject gameObj, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
            if (gameObj != null)
            {
                return AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop,
                                    gameObj, transitionDuration, curveInterpolation);
            }
            return AKRESULT.AK_Fail;
        }

        public AKRESULT StopSound2D(string eventName, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Stop,
                                globalAudioGameObject, transitionDuration, curveInterpolation);
            }
            return AKRESULT.AK_Fail;
        }

        public void StopAll()
        {
            if (AkSoundEngine.IsInitialized())
                AkSoundEngine.StopAll();
        }

        public AKRESULT PauseSound(string eventName, GameObject gameObj, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                if (gameObj != null)
                {
                    return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Pause,
                                    gameObj, transitionDuration, curveInterpolation);
                }
            }
            return AKRESULT.AK_Fail;
        }

        public AKRESULT UnPauseSound(string eventName, GameObject gameObj, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                if (gameObj != null)
                {
                    return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Resume,
                                    gameObj, transitionDuration, curveInterpolation);
                }
            }
            return AKRESULT.AK_Fail;
        }

        public AKRESULT PauseSound2D(string eventName, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                if (globalAudioGameObject != null)
                {
                    return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Pause,
                                    globalAudioGameObject, transitionDuration, curveInterpolation);
                }
            }
            return AKRESULT.AK_Fail;
        }

        public AKRESULT UnPauseSound2D(string eventName, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                if (globalAudioGameObject != null)
                {
                    return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Resume,
                                    globalAudioGameObject, transitionDuration, curveInterpolation);
                }
            }
            return AKRESULT.AK_Fail;
        }



        public AKRESULT SetState(string stateGroup, string state)
        {
            return AkSoundEngine.SetState(stateGroup, state);
        }

        public AKRESULT SetState(int stateGroupID, int stateValueID)
        {
            return AkSoundEngine.SetState((uint)stateGroupID, (uint)stateValueID);
        }

        public AKRESULT SetSwitch(string switchGroup, string switchName, GameObject go) 
        {
            return AkSoundEngine.SetSwitch(switchGroup, switchName, go);    
        }

        public AKRESULT SetRtpcValue(string rtpcName, float value, GameObject go)
        {
            return AkSoundEngine.SetRTPCValue(rtpcName, value, go);
        }

        public void LoadBank(string bankName)
        {
            if (!string.IsNullOrEmpty(bankName))
            {
                AkBankManager.LoadBank(bankName, false, false);
            }
        }
        public void LoadBankAsync(string bankName, AkCallbackManager.BankCallback callbackFunc)
        {
            if (!string.IsNullOrEmpty(bankName))
            {
                AkBankManager.LoadBankAsync(bankName, callbackFunc);
            }
        }
        public void UnloadBank(string bankName)
        {
            if (!string.IsNullOrEmpty(bankName))
            {
                AkBankManager.UnloadBank(bankName);
            }
        }

        public void PostEvents(AK.Wwise.Event[] events, GameObject obj)
        {
            if (AkSoundEngine.IsInitialized() && events != null)
            {
                for (int i = 0; i < events.Length; i++)
                {
                    events[i].Post(obj);
                }
            }
        }

        public void PostEvents(AK.Wwise.Event[] events)
        {
            if (AkSoundEngine.IsInitialized() && events != null)
            {
                for (int i = 0; i < events.Length; i++)
                {
                    events[i].Post(globalAudioGameObject);
                }
            }
        }

        /// <summary>
        /// 用于单一辅助轨道的动态发送
        /// </summary>
        /// <param name="auxReverbName"></param>
        /// <param name="sendValue"></param>
        /// <returns></returns>
        public AKRESULT SetSingleReverbAux(string auxReverbName, GameObject emitterGo, float sendValue = 1.0f)
        {
            AKRESULT res = AKRESULT.AK_Fail;
            if (AkSoundEngine.IsInitialized())
            {
                AkAuxSendArray sendA = new AkAuxSendArray();
                sendA.Reset();
                if (!string.IsNullOrEmpty(auxReverbName))
                {
                    sendA.Add((uint)AkSoundEngine.GetIDFromString(auxReverbName), sendValue);
                    res = AkSoundEngine.SetGameObjectAuxSendValues(emitterGo, sendA, (uint)sendA.Count());
                }
                else
                {
                    res = AkSoundEngine.SetGameObjectAuxSendValues(emitterGo, sendA, 0);
                }
            }
            return res;
        }

        #region 音量控制模块

        private const float minVolume = 0.0f;
        private const float maxVolume = 100.0f;

        public struct VolumeParam
        {
            public static string SoundVolume = "Sound_Volume";
            public static string VoiceVolume = "Voice_Volume";
            public static string MusicVolume = "Music_Volume";
        }

        public void SetSoundVolume(float volume)
        {
            volume = Mathf.Clamp(volume, minVolume, maxVolume);
            AkSoundEngine.SetRTPCValue(VolumeParam.SoundVolume, volume);
        }
        public void SetVoiceVolume(float volume)
        {
            volume = Mathf.Clamp(volume, minVolume, maxVolume);
            AkSoundEngine.SetRTPCValue(VolumeParam.VoiceVolume, volume);
        }
        public void SetMusicVolume(float volume)
        {
            volume = Mathf.Clamp(volume, minVolume, maxVolume);
            AkSoundEngine.SetRTPCValue(VolumeParam.MusicVolume, volume);
        }


        #endregion

#region 音频静音开关控制模块
        public struct AudioBusOnOff 
        {
            public static string Sound_On = "Sound_On";// mute bus event , Global Scope
            public static string Sound_Off = "Sound_Off";
            public static string Voice_On = "Voice_On";
            public static string Voice_Off = "Voice_Off";
            public static string Music_On = "Music_On";
            public static string Music_Off = "Music_Off";
            public static string Main_On = "Main_On";
            public static string Main_Off = "Main_Off";
        }

        /// <summary>
        /// 音效的打开、关闭
        /// </summary>
        /// <param name="isOn"></param>
        public void SetSoundOn(bool isOn)
        {
            PlaySound2D(isOn ? AudioBusOnOff.Sound_On : AudioBusOnOff.Sound_Off);
        }

        /// <summary>
        /// 语音的打开、关闭
        /// </summary>
        /// <param name="isOn"></param>
        public void SetVoiceOn(bool isOn)
        {
            PlaySound2D(isOn ? AudioBusOnOff.Voice_On : AudioBusOnOff.Voice_Off);
        }
        /// <summary>
        /// 音乐的打开、关闭
        /// </summary>
        /// <param name="isOn"></param>
        public void SetMusicOn(bool isOn)
        {
            PlaySound2D(isOn ? AudioBusOnOff.Music_On : AudioBusOnOff.Music_Off);
        }

        /// <summary>
        /// 全部音频的打开、关闭
        /// </summary>
        /// <param name="isOn"></param>
        public void SetMainOn(bool isOn)
        {
            PlaySound2D(isOn ? AudioBusOnOff.Main_On : AudioBusOnOff.Main_Off);
        }


#endregion




       


        #region 听者管理模块

        /// <summary>
        /// 重新指定某个Listener的position更新跟随overridePosition_Transform
        /// </summary>
        /// <param name="audioListener"></param>
        /// <param name="overridePosition_Transform"></param>
        public void SetAudioListenerPositionOverride(GameObject audioListener, Transform overridePosition_Transform)
        {
            if (audioListener != null && overridePosition_Transform != null)
            {
                GAMI.AudioListener listener = audioListener.GetComponent<GAMI.AudioListener>();
                if (listener != null) 
                {
                    listener.SetPositionOverride(overridePosition_Transform);
                }               
            }
        }

        /// <summary>
        /// 重置audiolistener的位置重写，回归默认自己的位置
        /// </summary>
        /// <param name="audioListener"></param>
        public void ResetAudioListenerPositionOverride(GameObject audioListener)
        {
            if (audioListener != null)
            {
                GAMI.AudioListener listener = audioListener.GetComponent<GAMI.AudioListener>();
                if (listener != null)
                {
                    listener.ResetPositionOverride();
                }
            }
        }


        /// <summary>
        /// 重新指定某个Listener的方向更新跟随overrideFowardUp_Transform
        /// </summary>
        /// <param name="audioListener"></param>
        /// <param name="overrideFowardUp_Transform"></param>
        public void SetAudioListenerFowardUpOverride(GameObject audioListener, Transform overrideFowardUp_Transform)
        {
            if (audioListener != null && overrideFowardUp_Transform != null)
            {
                GAMI.AudioListener listener = audioListener.GetComponent<GAMI.AudioListener>();
                if (listener != null)
                {
                    listener.SetFowardUpOverride(overrideFowardUp_Transform);
                }               
            }
        }

        /// <summary>
        /// 重置listener的朝向重写，回归默认跟随自身朝向
        /// </summary>
        /// <param name="audioListener"></param>
        public void ResetAudioListenerFowardUpOverride(GameObject audioListener)
        {
            if (audioListener != null)
            {
                GAMI.AudioListener listener = audioListener.GetComponent<GAMI.AudioListener>();
                if (listener != null)
                {
                    listener.ResetFowardUpOverride();
                }
            }
        }



        /// <summary>
        /// 获取listener的position
        /// </summary>
        /// <param name="audioListener"></param>
        /// <returns></returns>
        public Vector3 GetAudioListenerPosition(GameObject audioListener) 
        {
            Vector3 position = Vector3.zero;
            if (audioListener != null) 
            {
                GAMI.AudioListener listener = audioListener.GetComponent<GAMI.AudioListener>();
                if (listener != null)
                {
                    position = listener.GetPosition();
                }                
            }
            return position;
        }

        /// <summary>
        /// 获取listener的Forward
        /// </summary>
        /// <param name="audioListener"></param>
        /// <returns></returns>
        public Vector3 GetAudioListenerForward(GameObject audioListener)
        {
            Vector3 forward = Vector3.forward;
            if (audioListener != null)
            {
                GAMI.AudioListener listener = audioListener.GetComponent<GAMI.AudioListener>();
                if (listener != null) 
                {
                    forward = listener.GetForward();
                }               
            }
            return forward;
        }

        /// <summary>
        /// 获取listener的Up
        /// </summary>
        /// <param name="audioListener"></param>
        /// <returns></returns>
        public Vector3 GetAudioListenerUp(GameObject audioListener)
        {
            Vector3 up = Vector3.up;
            if (audioListener != null)
            {
                GAMI.AudioListener listener = audioListener.GetComponent<GAMI.AudioListener>();
                if (listener != null) 
                {
                    up = listener.GetUp();
                }               
            }
            return up;
        }


        private static bool default3DListenerChanged = false;
        private static ulong[] Default3DListenersIDs = { AkSoundEngine.AK_INVALID_GAME_OBJECT };//默认只允许有1个监听3d的listener，以最新指定的为准

        public void Set3DListener(GameObject go) 
        {
            ulong goId = AkSoundEngine.GetAkGameObjectID(go);
            if (goId != Default3DListenersIDs[0])
            {
                Default3DListenersIDs[0] = goId;
                default3DAudioListener = go;
                default3DListenerChanged = true;
            }
        }

        public void Remove3DListener(GameObject go)
        {
            if (go != null)
            {
                ulong goId = AkSoundEngine.GetAkGameObjectID(go);
                if (Default3DListenersIDs[0] == goId) 
                {                  
                    Default3DListenersIDs[0] = AkSoundEngine.GetAkGameObjectID(globalAudioGameObject);//指定global Listener为默认3dlistener
                    default3DAudioListener = go;
                    default3DListenerChanged = true;
                }
            }

        }

        public void Refresh3DListener()
        {
            if (default3DListenerChanged)
            {
                default3DListenerChanged = false;
                AkSoundEngine.SetDefaultListeners(Default3DListenersIDs, 1);//默认只允许有1个监听3d的listener
            }
            
        }











        #endregion

        #region id 版本api
        private HashSet<ulong> REGISTED_GO_IDs = new HashSet<ulong>();//注册的go id 统一管理

        public bool IsRegistedGoId(ulong goId) { return REGISTED_GO_IDs.Contains(goId); }
        public AKRESULT RegisterGoId(ulong goId, string goName)
        {
            AKRESULT res = AkSoundEngine.RegisterGameObjInternal_WithName(goId, goName);
            if (res == AKRESULT.AK_Success) { REGISTED_GO_IDs.Add(goId); }         
            return res;
        }

        public AKRESULT UnRegisterGoId(ulong goId) 
        {
            AKRESULT res = AkSoundEngine.UnregisterGameObjInternal(goId);
            if (res == AKRESULT.AK_Success) { REGISTED_GO_IDs.Remove(goId); }           
            return res;
        }

        /// <summary>
        /// 注销掉所有的已注册的go ID
        /// </summary>
        public void UnRegisterALLGoId()
        {
            for (int i = 0; i <REGISTED_GO_IDs.Count; i++)
            {
                AkSoundEngine.UnregisterGameObjInternal(REGISTED_GO_IDs.ElementAt(i));
            }
            REGISTED_GO_IDs.Clear();
        }



        public uint PlaySound(string eventName, ulong goId) 
        {
            return AkSoundEngine.PostEvent(eventName, goId);       
        }


        public AKRESULT PauseSound(string eventName, ulong goId, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Pause,
                goId, transitionDuration, curveInterpolation);
            }
            return AKRESULT.AK_Fail;
        }

        public AKRESULT UnPauseSound(string eventName, ulong goId, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Resume,
                                goId, transitionDuration, curveInterpolation);
            }
            return AKRESULT.AK_Fail;
        }

        public AKRESULT StopSound(string eventName, ulong goId, int transitionDuration = 300,
            AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                transitionDuration = Mathf.Clamp(transitionDuration, 0, 10000);
                return AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Stop,
                                goId, transitionDuration, curveInterpolation);
            }
            return AKRESULT.AK_Fail;
        }


        public AKRESULT SetSwitch(string switchGroupName, string switchName, ulong goId) 
        {
            return AkSoundEngine.SetSwitch(switchGroupName, switchName, goId);      
        }
        public AKRESULT SetRtpcValue(string rtpcName, float value, ulong goId)
        {
            return AkSoundEngine.SetRTPCValue(rtpcName, value, goId);
        }
        public AKRESULT SetObjectPosition(ulong goId, Vector3 position, Vector3 front, Vector3 top)
        {
            return AkSoundEngine.SetObjectPosition(goId, position, front, top);      
        }











#endregion 
















    }
}