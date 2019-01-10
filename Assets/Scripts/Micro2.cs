using UnityEngine;
using System.Collections;
 
 [RequireComponent(typeof(AudioSource))]
 public class Micro2 : MonoBehaviour {
     public float sensitivity = 100;
     public float loudness = 0;
    AudioSource src;
     void Start() {
         src = GetComponent<AudioSource>();
         //audio.clip = Microphone.Start(null, true, 10, 44100);
        src.clip = Microphone.Start (null, true, 10, 44100);
        // audio.loop = true; // Set the AudioClip to loop
         //audio.mute = true; // Mute the sound, we don't want the player to hear it
         while (!(Microphone.GetPosition (null) > 0)) {
        }
         src.Play(); // Play the audio source!
     }
 
     void Update(){
         loudness = GetAveragedVolume() * sensitivity;
         if(loudness>10){
         Debug.Log(loudness);
         }
     }
 
 float GetAveragedVolume()
     { 
         float[] data = new float[256];
         float a = 0;
         src.GetOutputData(data,0);
         foreach(float s in data)
         {
             a += Mathf.Abs(s);
         }
         return a/256;
     }
 }