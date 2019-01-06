using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {
    private Animator boca;
     private Animator body;
    public AudioSource audioData;

    // BOCA
    private int boca_A = Animator.StringToHash("boca_A");
	private int boca_E = Animator.StringToHash("boca_E");
    private int boca_I = Animator.StringToHash("boca_I");
    private int boca_O = Animator.StringToHash("boca_O");
    private int boca_U = Animator.StringToHash("boca_U");
    private int boca_X = Animator.StringToHash("boca_X");

    // BODY
    private int body_idle = Animator.StringToHash("Idle");
    private int body_Hello = Animator.StringToHash("Hello");
    private int body_blink = Animator.StringToHash("Blink");
  

    // Start is called before the first frame update
    void Start() {
        boca = this.gameObject.transform.GetChild(0).GetComponent<Animator> ();
        body = this.GetComponent<Animator> ();
        Debug.Log(body);
       
    }

    // Update is called once per frame
    void Update() {
       // Debug.Log(".");
        if(Input.GetKeyDown("a")){
            Debug.Log("test");
            StartCoroutine(SayText("1oooiii euu sou a Dora,  2    botas e eu estamos brincando de esconde esconde, voces querem brincar? 0 2 "));
                  
         audioData.Play(0);
        }
    }

     IEnumerator SayText(string s) {
        foreach (char c in s){
            Debug.Log(c);
            switch (c){
                case 'a':
                    boca.Play(boca_A);
                    break;
                case 'e':
                    boca.Play(boca_E);
                    break;
                case 'i':
                    boca.Play(boca_I);
                    break;
                case 'o':
                    boca.Play(boca_O);
                    break;
                case 'u':
                    boca.Play(boca_U);
                    break;
                case '0':
                    body.Play(body_idle);
                    break;
                case '1':
                    body.Play(body_Hello);
                    break;            
                case '2':
                    body.Play(body_blink);
                    break;
                default:
                    boca.Play(boca_X);
                    break;
            }
            yield return new WaitForSeconds(0.08f);
        }
    }
}
