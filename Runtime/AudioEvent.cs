
using UnityEngine;

[System.Serializable]
public class AudioEvent
{
   
    private float lastPlayTime;
    public string name;

    [System.Serializable]
    public struct CoolDown 
    {
        public float min;
        //[Range(0,1)]
        public float max;
    
    }

    public CoolDown coolDown;//冷却时间

    public uint Play(GameObject go) 
    {
        if (Time.time - lastPlayTime <= coolDown.max && Time.time - lastPlayTime >= coolDown.min) { return 0; }
        
        uint playingId = GAMI.AudioManager.Instance.PlaySound(name, go);
        if (playingId != AkSoundEngine.AK_INVALID_PLAYING_ID) { lastPlayTime = Time.time; }
        
        return playingId;

    }






}
