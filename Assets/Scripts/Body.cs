using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {
    public string spriteName;
    private Animator animator;
    private int body_idle;
    private int body_Hello;
    private int body_walk;
    void Start() {
        animator = this.GetComponent<Animator> ();
        body_idle = Animator.StringToHash(spriteName + "_body_idle");
        body_Hello = Animator.StringToHash(spriteName + "_body_hello");
        body_walk = Animator.StringToHash(spriteName + "_body_walk");
    }
    public void MoveUI(){
            Vector3 walk_distance = new Vector3(0.2f,0,0);
            this.transform.parent.transform.position += walk_distance;
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
                    animator.Play(body_walk);
                  
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
