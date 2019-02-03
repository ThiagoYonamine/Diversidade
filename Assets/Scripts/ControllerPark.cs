using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPark : MonoBehaviour
{
    public GameObject bia;
    public GameObject[] friends;
    
    private bool playing = true;
    // Update is called once per frame
    private Player biaScript;
    void Start() {
        biaScript= bia.GetComponent<Player>();
    }
    void Update()  {
        if(playing){
            int count = 0;
            foreach(GameObject obj in friends) {
                if(!obj.activeSelf) {
                    break;
                } 
                count++;
            }
            if(count == friends.Length){
               biaScript.NextStep(3);
               playing = false;
            } 
        }

    }
}
