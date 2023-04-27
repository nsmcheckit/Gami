using UnityEngine;
using UnityEngine.Playables;

namespace GAMI 
{
    public class AudioPlayableBehavioour : PlayableBehaviour
    {
        public string playEvent;
        public string eventWhenEndOfTrack;
        public bool forceStopAtEndOfTrack;
        public GameObject SoundGameObject;
        
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            PlaySound(playEvent,SoundGameObject);
        }

        public override void OnPlayableDestroy(Playable playable)
        {
            base.OnPlayableDestroy(playable);
            if (this.forceStopAtEndOfTrack)
            {
                StopSound(playEvent, SoundGameObject);
            }
            PlaySound(eventWhenEndOfTrack, SoundGameObject);
        }


        public void PlaySound(string eventName, GameObject go)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                AkSoundEngine.PostEvent(eventName, go);
            }
        }

        public void StopSound(string eventName, GameObject go)
        {
            if (!string.IsNullOrEmpty(eventName))
            {
                AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Stop, go);
            }
        }


    }
}



