using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

namespace GAMI 
{
    [UnityEngine.Timeline.TrackColor(0.855f, 0.8623f, 0.870f)]
    [UnityEngine.Timeline.TrackClipType(typeof(AudioPlayableAsset))]
    //[UnityEngine.Timeline.TrackBindingType(typeof(UnityEngine.GameObject))]
    public class AudioPlayableTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(UnityEngine.Playables.PlayableGraph graph, UnityEngine.GameObject go, int inputCount)
        {
            var playable = UnityEngine.Playables.ScriptPlayable<AudioPlayableBehavioour>.Create(graph);
            UnityEngine.Playables.PlayableExtensions.SetInputCount(playable, inputCount);
            
            var clips = GetClips();
            foreach (var clip in clips)
            {
                var audioPlayableAsset = clip.asset as AudioPlayableAsset;
                
            }
            return playable;
        }
    }
}

