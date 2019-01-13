using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraman : MonoBehaviour {
    private float x; 
    private float player_x; 
    public GameObject player;
    // Start is called before the first frame update
    void Start() {
        x = this.transform.position.x;
        player_x = player.transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        x = this.transform.position.x;
        player_x = player.transform.position.x;
        if (player_x+2 >= x) {
            Vector3 walk_distance = new Vector3(0.025f,0,0);
            this.transform.position += walk_distance;
        }
    }
}
