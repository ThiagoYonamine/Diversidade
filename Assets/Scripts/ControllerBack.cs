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
    }

    // Update is called once per frame
    void Update()
    {
        if(biaScript.getStep()==0){
            if(PlayerPrefs.GetString("Choice02") == "01-Boat") {
                biaScript.NextStep(1);
            } else {
                biaScript.NextStep(2);
            }
            
        }
    }
}
