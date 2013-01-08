using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour {
	
	public float rotationAngle;
	public float rotationTime;
	
	private Transform thisTransform;
	
	// Use this for initialization
	void Start () {
		
		iTween.RotateBy(this.gameObject, iTween.Hash("z", rotationAngle,"time", rotationTime, "easeType", "easeInOutSine","loopType","pingPong"));//, "delay", 0.4));
		iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("Security1"), "time", 4, "looptype", iTween.LoopType.pingPong, "easeType", "easeInOutSine"));
	}
	
	// Update is called once per frame
	void Update ()  {
	
	}
}
