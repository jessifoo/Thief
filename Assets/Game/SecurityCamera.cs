using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour {
	
	public float rotationAngle;
	public GameObject frameOfView;
	
	private Transform thisTransform;
	
	// Use this for initialization
	void Start () {
		
		iTween.RotateBy(this.gameObject, iTween.Hash("z", rotationAngle,"time", 2, "easeType", "easeInOutSine","loopType","pingPong"));//, "delay", 0.4));
	}
	
	// Update is called once per frame
	void Update () {
		//frameOfView.transform.Rotate(10* Vector3.forward * Time.deltaTime);
		//Quaternion rot = thisTransform.rotation;
		//transform.Rotate(rotationSpeed* Vector3.forward * Time.deltaTime);
		
		
	
	}
}
