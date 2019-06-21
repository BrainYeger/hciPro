using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class click : MonoBehaviour {

	public Slider clipStrip;
	private GameObject gameObject;
	public int speed = 20;
	public GameObject bullet;
	//public Rigidbody bullet;
	public Transform fpoint;
	public int amount = 5;
	// Use this for initialization
	void Start () {

		gameObject = GameObject.Find ("Canvas/focus");
		gameObject.SetActive(false);

		GameObject shot = GameObject.Find ("Canvas/shot_button");
		Button btn_shot = (Button)shot.GetComponent<Button> ();
		btn_shot.onClick.AddListener (on_click_shot);

		GameObject focus = GameObject.Find ("Canvas/focus_button");
		Button btn_focus = (Button)focus.GetComponent<Button> ();
		btn_focus.onClick.AddListener (on_click_focus);

		GameObject add_clip = GameObject.Find ("Canvas/add_clip");
		Button btn_add = (Button)add_clip.GetComponent<Button> ();
		btn_add.onClick.AddListener (on_click_add);

	}


	//onclick shot_button will happen...
	void on_click_shot(){
		if (amount > 0) {
			//Rigidbody clone;
			//clone = (Rigidbody)Instantiate (bullet, fpoint.position, fpoint.rotation);
			//clone.velocity = transform.TransformDirection (Vector3.forward * speed);
			GameObject clone;
			clone = (GameObject)Instantiate (bullet, fpoint.position, fpoint.rotation);
			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection (Vector3.forward* speed);

			amount--;
			Destroy (clone, 10.0f);
			clipStrip.value -= 1;

		}

		
	}
	//onclick focus_button will happen..
	void on_click_focus(){
		if (gameObject.activeSelf == true){
			gameObject.SetActive(false);
		}
		else {
			gameObject.SetActive(true);
		} 
	}

	//onclick add_clip will happen..
	void on_click_add(){
		clipStrip.value = 5;
		amount = 5;
	}

	void Update () {
		
	}
}
