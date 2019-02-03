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
    void onActivityResult(string recognizedText) {
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        int size = resultDic.Length;
        Debug.Log("RESULT: " + result[0]);
        for(int i=0 ; i<size ; i++){
            if(needNumber){
                if(!isStringANumber(result[0])) continue;
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

    private bool isStringANumber(string s){
        int n;
        return int.TryParse(s, out n);
    }

}
