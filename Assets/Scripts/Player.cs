using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class Player : MonoBehaviour {

    private GameObject mouth;
    private Mouth mouthScript;

    private GameObject body;
    private Body bodyScript;

    private GameObject eyes;
    private Eyes eyesScript;

    private string path = "Assets/Texts/test.txt";
    private string[] texts;
    public AudioSource audioData;
    public AudioSource audioData2;
    private int step;
    void Start() {
        step = 0;
        //boca = this.gameObject.transform.GetChild(0).GetComponent<Animator> ();
        mouth = this.gameObject.transform.GetChild(0).gameObject;
        mouthScript = mouth.GetComponent<Mouth>();
        body = this.gameObject.transform.GetChild(1).gameObject;
        bodyScript = body.GetComponent<Body>();
        eyes = this.gameObject.transform.GetChild(2).gameObject;
        eyesScript = eyes.GetComponent<Eyes>();

        StreamReader reader = new StreamReader(path); 
        string file= reader.ReadToEnd();
        reader.Close();
        texts = file.Split(new string[] { ";" }, StringSplitOptions.None);
        foreach (string s in texts){
            Debug.Log(s);
        }
    }

    // Update is called once per frame
    void Update() {
       // Debug.Log(".");
        if(Input.GetKeyDown("a")){
            StartCoroutine(Control(texts[step]));
            audioData.Play(0);
        }
    }
    public void NextStep(int step) {
            StartCoroutine(Control(texts[step]));
            audioData2.Play(0);
    }
     IEnumerator Control(string s) {
        foreach (char c in s) {
            if((int)c >= (int)'0' && (int)c <= (int)'9'){
                bodyScript.Move(c);
            } else if (c=='(' || c==')') {
                eyesScript.BlinkEyes(c);
            } else {
                mouthScript.SayText(c);
                yield return new WaitForSeconds(0.08f);
            }
        }
           
    }
    
}
