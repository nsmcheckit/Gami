using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "fffffckuuuu",menuName ="Assets/ooooozcg")]
public class AudioEventScriptable : ScriptableObject
{
    
    [SerializeField] private List<AudioEvent> events = new List<AudioEvent>();
    private Dictionary<string, AudioEvent> eventsDict = new Dictionary<string, AudioEvent>();

    private static AudioEventScriptable m_instance;

    static int m_index = 0;
    public static AudioEventScriptable Instance 
    {
        get 
        {
            Debug.LogError("fck instance");
            //m_instance = CreateInstance<AudioEventScriptable>();
            if (m_instance == null) 
            {
                m_index++;
                Debug.Log(m_index);
                m_instance = Resources.Load<AudioEventScriptable>("fffffckuuuu");
            }
                

            return m_instance;
        }
    }
    public AudioEvent this[string eventName]
    {
        get
        {
            if (eventsDict.TryGetValue(eventName, out var audioEvent))
                return audioEvent;
            return null;
        }
        
    }

    public AudioEvent Get(string eventName) 
    {
        if (eventsDict.TryGetValue(eventName, out var audioEvent))
            return audioEvent;
        return new AudioEvent();
    }

    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        Debug.LogError("fck enable");
        foreach (var aEvent in events)
        {
            if (!eventsDict.ContainsKey(aEvent.name))
            {
                eventsDict.Add(aEvent.name, aEvent);
            }

        }
    }

    private void OnDestroy()
    {
        
    }

}
