using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
public class Player : MonoBehaviour {

    private GameObject mouth;
    private Mouth mouthScript;

    private GameObject body;
    private Body bodyScript;

    private GameObject eyes;
    private Eyes eyesScript;


    public TextAsset textFile;
    public TextAsset buttonFile;
    public Text log;

    private string[] textsGuide;
    private string[] buttonsGuide;
    private string[] audioGuide;
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    private int step;

    public GameObject buttons;
    void Start() {
        step = 0;
        mouth = this.gameObject.transform.GetChild(0).gameObject;
        mouthScript = mouth.GetComponent<Mouth>();
        body = this.gameObject.transform.GetChild(1).gameObject;
        bodyScript = body.GetComponent<Body>();
        eyes = this.gameObject.transform.GetChild(2).gameObject;
        eyesScript = eyes.GetComponent<Eyes>();
        LoadText();
        LoadButtons();
        HideAllButtons();

   
    }

    private void LoadText() {
        textsGuide = textFile.text.Split(new string[] { ";" }, StringSplitOptions.None);   
    }

    private void LoadButtons() {
        buttonsGuide = buttonFile.text.Split(new string[] { ";" }, StringSplitOptions.None);
    }

    private void HideAllButtons() {
        int total = buttons.transform.childCount;
        for(int i=0; i<total; i++){
            GameObject button = buttons.transform.GetChild(i).gameObject;
            button.SetActive(false);
        }
    }

    private void ShowButtons() {
        string[] buttonsNumbers = buttonsGuide[step].Split(new string[] { " " }, StringSplitOptions.None);
        foreach(string s in buttonsNumbers) {
            Debug.Log(s);
            buttons.transform.GetChild(int.Parse(s)).gameObject.SetActive(true);
        }
    }

    public void NextStep(int newstep) {
            step = newstep;
            StartCoroutine(Control(textsGuide[step]));
            log.text = textsGuide[step];
            HideAllButtons();
    }

    public void NextStep() {
            step++;
            StartCoroutine(Control(textsGuide[step]));
            log.text = textsGuide[step];
            HideAllButtons();
    }

    public void RepeatStep() {
            log.text = "Ah muleke vai sim! FALA SIMMM";
    }
     IEnumerator Control(string s) {
        foreach (char c in s) {
            if((int)c >= (int)'0' && (int)c <= (int)'9'){
                bodyScript.Move(c);
            } else if (c=='(' || c==')') {
                eyesScript.BlinkEyes(c);
            } else if (c=='!') {
                ShowButtons();
            } else if (c=='#') {
                audioSource.clip = audioClips[step];
                audioSource.Play(0);
            } else {
                mouthScript.SayText(c);
                if(c=='x') {
                     yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(0.08f);
            }
        }           
    }
    
}
