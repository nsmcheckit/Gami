using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WwiseRecorder : WwiseOfflineRenderer
{


	public override string GetUniqueScreenshotFileName(int frameCount)
	{
		return "";
	}

	public override void ProcessAudioSamples(float[] buffer)
	{
		//MovieRecorderSettings settings = new MovieRecorderSettings();
		//MediaEncoderManager s;
		
	

    }


	//public void OnAudioFilterRead(float[] data, int channels)
	//{
	//	data= new float[channels];
	//	Array.Copy(BUFFER, data, data.Length);
	//}

}
