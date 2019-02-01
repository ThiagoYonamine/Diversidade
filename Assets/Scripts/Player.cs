using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;
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
    Coroutine coroutine;

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
        StartCoroutine(InitGame());

    }

    public int getStep(){
        return step;
    }

    public void setFirstChoice(string v) {
            PlayerPrefs.SetString("FirstChoice", v);
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
            Debug.Log("GOTO: " + step);
            coroutine = StartCoroutine(Control(textsGuide[step]));
           // log.text = textsGuide[step];
            HideAllButtons();
    }

    private void getJump(string s){
        Debug.Log("JUMP: " + s);
        bool isScene = false;
        if(s[1]=='S') isScene = true;
        for(int i=2;i<s.Length;i++) {
            if(s[i]!=']') continue;
            if (isScene) { 
                SceneManager.LoadScene(s.Substring(2,i-2).ToString(), LoadSceneMode.Single);
                return;
            } else {
                Debug.Log("JUMP: " + s.Substring(2, i-2).ToString());
                NextStep(int.Parse(s.Substring(2, i-2).ToString()));
                return;
            }
        }
            return;  
    }
     IEnumerator InitGame() {
         yield return new WaitForSeconds(1f);
         NextStep(0);
    }
     IEnumerator Control(string s) {
       
        for(int i=0;i<s.Length;i++) {
            char c = s[i];
            if (c=='[') {
                StopCoroutine(coroutine);
                getJump(s.Substring(i));
                yield return 0;
            } else if(c=='M') {
                string movement = s.Substring(i+1,2);
                if (movement == "03") {
                    eyesScript.BlinkEyes('.');
                    mouthScript.SayText('.');
                } 
                bodyScript.Move(movement);
            } else if (c=='(' || c==')' || c=='?') {
                eyesScript.BlinkEyes(c);
            } else if (c=='!') {
                ShowButtons();
            } else if (c=='#') {
                audioSource.clip = audioClips[step];
                audioSource.Play(0);
            } else {
                if(c=='x') {
                     yield return new WaitForSeconds(1f);
                } else if (!(c >= '0' && c <= '9')) {
                    mouthScript.SayText(c);
                    yield return new WaitForSeconds(0.07f);
                }
            }
        }           
    }
    
}
