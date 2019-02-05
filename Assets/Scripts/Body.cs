using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {
    public string spriteName;
    private Animator animator;
    private int body_idle;
    private int body_Hello;
    private int body_walk;
    private int body_jump;
    private int body_question;
    private int body_idea;
    private int body_back;
    private int[] body_count = new int[10];
    void Start() {
        animator = this.GetComponent<Animator> ();
        body_idle = Animator.StringToHash(spriteName + "_body_idle");
        body_Hello = Animator.StringToHash(spriteName + "_body_hello");
        body_walk = Animator.StringToHash(spriteName + "_body_walk");
        body_jump = Animator.StringToHash(spriteName + "_body_jump");
        body_question  = Animator.StringToHash(spriteName + "_body_question");
        body_idea  = Animator.StringToHash(spriteName + "_body_idea");
        body_back = Animator.StringToHash(spriteName + "_body_back");
        for(int i=0;i<9;i++){
             body_count[i] = Animator.StringToHash(spriteName + "_C0" + (i+1).ToString());
        }
        body_count[9] = Animator.StringToHash(spriteName + "_C10");


    }
    public void MoveUI(int inverse = 0) {
            Vector3 walk_distance = new Vector3(0.2f,0,0);
            if(inverse == 0) {
                this.transform.parent.transform.position += walk_distance;
            } else {
                this.transform.parent.transform.position -= walk_distance;
            }

    }

    public void Move(string c) {
            Debug.Log("MOV: " + c);
            switch (c){
                case "00":
                    animator.Play(body_idle);
                    break;
                case "01":
                    animator.Play(body_Hello);
                    break;
                case "02":
                    animator.Play(body_walk);
                    break;
                case "03":
                    animator.Play(body_jump);
                    break;
                case "04":
                    animator.Play(body_question);
                    break;
                case "05":
                    animator.Play(body_idea);
                    break;
                case "07":
                    animator.Play(body_back);
                    break;

                case "C1":
                    animator.Play(body_count[0]);
                    break;
                case "C2":
                    animator.Play(body_count[1]);
                    break;
                case "C3":
                    animator.Play(body_count[2]);
                    break;
                case "C4":
                    animator.Play(body_count[3]);
                    break;
                case "C5":
                    animator.Play(body_count[4]);
                    break;
                case "C6":
                    animator.Play(body_count[5]);
                    break;
                case "C7":
                    animator.Play(body_count[6]);
                    break;
                case "C8":
                    animator.Play(body_count[7]);
                    break;
                case "C9":
                    animator.Play(body_count[8]);
                    break;
                case "10":
                    animator.Play(body_count[9]);
                    break;
                default:
                    break;
            }    
    }
}
