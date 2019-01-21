using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
   private Animator animator;
   public string spriteName;
    private int eyes_open;
    private int eyes_close;
    private int eyes_hide;
    private int eyes_question;

    void Start() {
        animator = this.GetComponent<Animator> ();
        eyes_open = Animator.StringToHash(spriteName + "_eye_open");
        eyes_close = Animator.StringToHash(spriteName + "_eye_close");
        eyes_hide = Animator.StringToHash(spriteName + "_eye_hide");
        eyes_question = Animator.StringToHash(spriteName + "_eye_question");
    }

    public void BlinkEyes(char c) {
            switch (c){
                case '(':
                    animator.Play(eyes_open);
                    break;
                case ')':
                    animator.Play(eyes_close);
                    break;
                case '?':
                    animator.Play(eyes_question);
                    break;
                case '.':
                    animator.Play(eyes_hide);
                    break;
                default:
                    break;
            }    
    }
}
