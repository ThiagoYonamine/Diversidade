using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ControllerEscada : MonoBehaviour {

    public GameObject personagem;
	public bool isCompleted;
	private static int pieces;
	private int totalPieces=5;

	void Start () {
		pieces = 0;
		isCompleted = false;
	}
	
	public static void completePiece(){
		pieces++;
        Debug.Log(pieces);
	}

	void Update() {
		if(pieces == totalPieces && !isCompleted){
			showFeedback();
		}
	}

	void showFeedback(){
		isCompleted= true;
        personagem.GetComponent<Player>().NextStep(5);

	}
	
}
