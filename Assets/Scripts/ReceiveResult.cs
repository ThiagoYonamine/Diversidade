using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

	// Use this for initialization
    public GameObject player;
	void Start () {
        //GameObject.Find("Text").GetComponent<Text>().text = "You need to be connected to Internet";
         this.GetComponent<Text>().text ="Hi Thiago";
	}
	
    void onActivityResult(string recognizedText) {
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        //You can get the number of results with result.Length
        //And access a particular result with result[i] where i is an int
        //I have just assigned the best result to UI text
        this.GetComponent<Text>().text = result[0];
        if(result[0] == "sim") {
            player.GetComponent<Player>().NextStep();
        }

         else {
            player.GetComponent<Player>().RepeatStep();
        }

    }

    public void sim(){
         player.GetComponent<Player>().NextStep();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
