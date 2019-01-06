using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
   private Animator animator;
    private int eyes_open = Animator.StringToHash("01_eye_open");
    private int eyes_close = Animator.StringToHash("01_eye_close");

    void Start() {
        animator = this.GetComponent<Animator> ();
    }
     public void BlinkEyes(char c) {
            switch (c){
                case '(':
                    animator.Play(eyes_open);
                    break;
                case ')':
                    animator.Play(eyes_close);
                    break;
                default:
                    break;
            }    
    }
}
