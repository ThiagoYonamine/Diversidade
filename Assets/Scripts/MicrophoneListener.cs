﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class MicrophoneListener : MonoBehaviour {
    Button btn;
    public string returnName;
	// Use this for initialization
	void Start () {
       
	}
	
    public void StartMicrophone() {   
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.plugin.speech.pluginlibrary.TestPlugin");
        Debug.Log("Call 1 Started");

        // Pass the name of the game object which has the onActivityResult(string recognizedText) attached to it.
        // The speech recognizer intent will return the string result to onActivityResult method of "Main Camera"
        pluginClass.CallStatic("setReturnObject", returnName);
        Debug.Log("Return Object Set");


        // Setting language is optional. If you don't run this line, it will try to figure out language based on device settings
        pluginClass.CallStatic("setLanguage", "pt_BR");
        Debug.Log("Language Set");


        // The following line sets the maximum results you want for recognition
        pluginClass.CallStatic("setMaxResults", 5);
        Debug.Log("Max Results Set");

        // The following line sets the question which appears on intent over the microphone icon
        pluginClass.CallStatic("changeQuestion", "Fale no microfone");
        Debug.Log("Question Set");


        Debug.Log("Call 2 Started");

        // Calls the function from the jar file
        pluginClass.CallStatic("promptSpeechInput");

        Debug.Log("Call End");
    }

 
 }