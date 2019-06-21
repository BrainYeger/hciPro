using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Hurt : MonoBehaviour {
	public Slider blood;
	public Text t;
	// Use this for initialization
	void Start () {
		//t.GetComponent<Text>().text = "FAILED";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void gethurt(int num){
		blood.value -= num;
		if (blood.value <= 0) {
			//failed.
			t.GetComponent<Text>().text = "FAILED";
		}
	}
}
