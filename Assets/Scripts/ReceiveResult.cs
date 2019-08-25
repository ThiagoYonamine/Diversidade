using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

	// Use this for initialization
    public GameObject player;

    public string[] resultDic;
    public int[] steps;
    public bool needNumber=false;
    public int stepBack=-1;
    void onActivityResult(string recognizedText) {
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        if(!PlayerPrefs.HasKey("WrongAge")){
             PlayerPrefs.SetInt("WrongAge", 0); 
        }
        int wrongAge =PlayerPrefs.GetInt("WrongAge");

        int size = resultDic.Length;

        int age = haveNumber(result);
        for(int i=0 ; i<size ; i++) {
            if(needNumber){
                if(age <= -1) {
                    wrongAge++;
                    PlayerPrefs.SetInt("WrongAge", wrongAge);
                    if(wrongAge >= 2 ) stepBack = 9;
                    player.GetComponent<Player>().NextStep(stepBack);
                    return;
                } else if(age.ToString() == resultDic[i] || resultDic[i]== "true") {
                    player.GetComponent<Player>().NextStep(steps[i]);
                    return;
                }
            } 
            if(result[0] == resultDic[i] || resultDic[i]== "true" ) {  
                 Debug.Log("RESULT: " + result[0] + "Dic: " + resultDic[i] + "Step: " + i);     
                player.GetComponent<Player>().NextStep(steps[i]);
                return;
            }
        }
         
        player.GetComponent<Player>().NextStep(steps[size]);
        return;
        
    }

    public void sendResult(string s){
        onActivityResult(s);
    }


    private int haveNumber(string[] input) {
        int have = -1;
        char[] delimiterChar = {' '};
        
        for(int i=0 ; i< input.Length ; i++) {
            if(input[i] != null){
                string[] words = input[i].Split(delimiterChar);
                for(int j=0 ; j< words.Length ; j++) {
                    if (int.TryParse(words[j], out have))  {
                        return have;
                    } else {
                        have = -1;
                    }
                }
            }
        }
      return have;
    }

}
