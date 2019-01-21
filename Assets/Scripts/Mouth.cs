using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour {
    private Animator animator;
    private int boca_A = Animator.StringToHash("boca_A");
	private int boca_E = Animator.StringToHash("boca_E");
    private int boca_I = Animator.StringToHash("boca_I");
    private int boca_O = Animator.StringToHash("boca_O");
    private int boca_U = Animator.StringToHash("boca_U");
    private int boca_hide = Animator.StringToHash("boca_hide");
    private int boca_happy = Animator.StringToHash("boca_happy");
    private int boca_X = Animator.StringToHash("boca_X"); 

    // Start is called before the first frame update
    void Start() {       
        animator = this.GetComponent<Animator> ();
    }

     public void SayText(char c) {
            switch (c){
                case 'a':
                    animator.Play(boca_A);
                    break;
                case 'e':
                    animator.Play(boca_E);
                    break;
                case 'i':
                    animator.Play(boca_I);
                    break;
                case 'o':
                    animator.Play(boca_O);
                    break;
                case 'u':
                    animator.Play(boca_U);
                    break;
                case 'H':
                    animator.Play(boca_happy);
                    break;
                case '.':
                    animator.Play(boca_hide);
                    break;
                default:
                    animator.Play(boca_X);
                    break;
            }    
    }
}
