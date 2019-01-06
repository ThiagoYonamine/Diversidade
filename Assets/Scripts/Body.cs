using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {
    private Animator animator;
    private int body_idle = Animator.StringToHash("Idle");
    private int body_Hello = Animator.StringToHash("Hello");

  
    void Start() {
        animator = this.GetComponent<Animator> ();
    }
     public void Move(char c) {
            switch (c){
                case '0':
                    animator.Play(body_idle);
                    break;
                case '1':
                    animator.Play(body_Hello);
                    break;
                case '2':
                    break;
                case '3':
                    
                    break;
                case '4':
                    
                    break;
                default:
                   
                    break;
            }    
    }
}
