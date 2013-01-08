using UnityEngine;
using System.Collections;

public class CameraScan : MonoBehaviour {
	
	private IRageSpline rageSpline;
	private bool onAlert = false;
	
	// Use this for initialization
	void Start () {
		rageSpline = GetComponent(typeof(RageSpline)) as IRageSpline;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void OnCollisionEnter(Collision collision) {
		
		foreach (ContactPoint contact in collision.contacts) {
			if (contact.otherCollider.name == "Ship") {
				print ("ship hit");
				rageSpline.SetFillColor1(new Color(1f, 0f, 0f));
				rageSpline.RefreshMesh();
			}
			if (contact.otherCollider.name == "RedTower") {
				//print ("hitting red tower");
			}
		}
	}*/
	
	IEnumerator SecurityAlert() {
		print ("ship triggered scan");
		onAlert = true;
		rageSpline.SetFillColor1(new Color(1f, 0f, 0f));
		rageSpline.RefreshMesh();
		
		yield return new WaitForSeconds(2f);
		
		onAlert = false;
		rageSpline.SetFillColor1(new Color(0f, 0f, 1f));
		rageSpline.RefreshMesh();
	}
	
	void OnTriggerEnter(Collider other) {
		print ("on trigger");
		if (other.name == "Thief") {
			if (!onAlert)
				StartCoroutine(SecurityAlert());
		}
	}
	/*
	void OnTriggerExit(Collider other) {
		print ("trigger exit");
		if (other.name == "Thief") {
			print ("ship trigger left");
			rageSpline.SetFillColor1(new Color(0f, 0f, 1f));
			rageSpline.RefreshMesh();
		}
	}
		
	void OnTriggerStay(Collider other) {
		if (other.name == "Thief") {
			print ("ship triggered scan");
			rageSpline.SetFillColor1(new Color(1f, 0f, 0f));
			rageSpline.RefreshMesh();
		}
	}
	*/


}
