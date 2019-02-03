using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBack : MonoBehaviour
{
    public GameObject Bia;
    private Player biaScript;
    // Start is called before the first frame update
    void Start()
    {
           biaScript= Bia.GetComponent<Player>();
            if(biaScript.getStep()==0){
                if(PlayerPrefs.GetString("Choice01") == "01-Boat") {
                    PlayerPrefs.SetString("Choice02", "01-Bridge");
                    biaScript.NextStep(2);
                } else {
                    PlayerPrefs.SetString("Choice02", "01-Boat");
                    biaScript.NextStep(1);
                }    
        }
    }
}
