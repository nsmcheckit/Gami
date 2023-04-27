using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WwiseOfflineRenderer : UnityEngine.MonoBehaviour

{

    public bool IsOfflineRendering { get; set; }

    public bool StartWithOfflineRenderingEnabled = false;

    private bool IsCurrentlyOfflineRendering = false;

    public float FrameRate = 25.0f;

    protected ulong OutputDeviceId = 0;

    public uint sampleCount;

    public abstract string GetUniqueScreenshotFileName(int frameCount);

    public abstract void ProcessAudioSamples(float[] buffer);

    public float[] BUFFER;

    protected void Start()

    {
        Debug.Log("f");
        OutputDeviceId = AkSoundEngine.GetOutputID(AkSoundEngine.AK_INVALID_UNIQUE_ID, 0);

        if (StartWithOfflineRenderingEnabled)

        {

            IsOfflineRendering = true;

            Update();

        }

    }



    private void LogAudioFormatInfo()

    {

        var sampleRate = AkSoundEngine.GetSampleRate();

        var channelConfig = new AkChannelConfig();

        var audioSinkCapabilities = new Ak3DAudioSinkCapabilities();

        AkSoundEngine.GetOutputDeviceConfiguration(OutputDeviceId, channelConfig, audioSinkCapabilities);

        UnityEngine.Debug.LogFormat("Sample Rate: {0}, Channels: {1}", sampleRate, channelConfig.uNumChannels);

    }



    protected void Update()

    {

        if (IsOfflineRendering != IsCurrentlyOfflineRendering)

        {

            IsCurrentlyOfflineRendering = IsOfflineRendering;

            if (IsOfflineRendering)

            {

#if UNITY_EDITOR

                // 确保 Editor 更新不会调用 AkSoundEngine.RenderAudio()。

                AkSoundEngineController.Instance.DisableEditorLateUpdate();

#endif



                LogAudioFormatInfo();



                AkSoundEngine.ClearCaptureData();

                AkSoundEngine.StartDeviceCapture(OutputDeviceId);

            }

            else

            {

                AkSoundEngine.StopDeviceCapture(OutputDeviceId);



#if UNITY_EDITOR

                // 恢复 Editor 更新对 AkSoundEngine.RenderAudio() 的调用。

                AkSoundEngineController.Instance.EnableEditorLateUpdate();

#endif

            }

        }



        var frameTime = IsOfflineRendering && FrameRate != 0.0f ? 1.0f / FrameRate : 0.0f;
        
        UnityEngine.Time.captureDeltaTime = frameTime;



        AkSoundEngine.SetOfflineRenderingFrameTime(0.0f);

        AkSoundEngine.SetOfflineRendering(IsOfflineRendering);



        if (!IsOfflineRendering)

            return;



        UnityEngine.ScreenCapture.CaptureScreenshot(GetUniqueScreenshotFileName(UnityEngine.Time.frameCount));



        sampleCount = AkSoundEngine.UpdateCaptureSampleCount(OutputDeviceId);

        if (sampleCount <= 0)

            return;



        BUFFER = new float[sampleCount];

        var count = AkSoundEngine.GetCaptureSamples(OutputDeviceId, BUFFER, (uint)BUFFER.Length);

        if (count <= 0)

            return;

        

        ProcessAudioSamples(BUFFER);

    }

}