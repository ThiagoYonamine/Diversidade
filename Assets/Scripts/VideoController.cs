using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
 
public class VideoController : MonoBehaviour {
public VideoPlayer vid;
public string scene;
public bool isFinal = false; 
 
void Start(){
    vid.loopPointReached += CheckOver;
      Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
 
    void CheckOver(UnityEngine.Video.VideoPlayer vp) {
        vid.enabled = false;

        if (PlayerPrefs.HasKey("Choice02")) {
            SceneManager.LoadScene("01-Fim", LoadSceneMode.Single);
        } else {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    public void Skip(){
         if (PlayerPrefs.HasKey("Choice02") && isFinal) {
            SceneManager.LoadScene("01-Fim", LoadSceneMode.Single);
        } else {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
 
}