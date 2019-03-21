using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBack : MonoBehaviour
{
    public GameObject Bia;
    private Player biaScript;
    private bool redirect;
    // Start is called before the first frame update
    void Start()  {
           biaScript= Bia.GetComponent<Player>();
           
            StartCoroutine(waitStart());
    }
    
   IEnumerator waitStart() {
         yield return new WaitForSeconds(1.5f);
         redirect=true;
    }

    void Update(){
         if(biaScript.getStep()==0 && redirect){
            redirect = false;
             Debug.Log("ENTREI AQUI");
                if(PlayerPrefs.GetString("Choice01") == "01-Boat") {
                    PlayerPrefs.SetString("Choice02", "01-Bridge");
                    biaScript.NextStep(1);
                    Debug.Log("Step: Choice02 01-Bridge");
                } else {
                    PlayerPrefs.SetString("Choice02", "01-Boat");
                    biaScript.NextStep(2);
                }    
           }
    }
}
