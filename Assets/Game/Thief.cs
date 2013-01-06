using UnityEngine;
using System.Collections;

public class Thief : MonoBehaviour {
	
	// Thief attributes
    public float maxSpeed;
    public float moveSpeed;
    public float turnSpeed;
	// Particle system
    public float origParticleMinSize;
    public float origParticleMaxSize;
    public float origParticleLocalYSpeed;
    public ParticleEmitter emitter;
	
	public int itemsPickedUp;
	
	private bool mouseDown = false;
	
	public GUIText itemsPickedUpText;
	
	

	// Use this for initialization
	void Start () {
        origParticleMinSize = emitter.minSize;
        origParticleMaxSize = emitter.maxSize;
        origParticleLocalYSpeed = emitter.localVelocity.y;
		itemsPickedUp = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
       
		if (Input.GetMouseButtonDown(0))
			mouseDown = true;
		if (Input.GetMouseButtonUp(0))
			mouseDown = false;
		
		if (mouseDown)
			UpdateThiefVelocity();

        UpdateParticleTrail();
		
		itemsPickedUpText.text = "Items Picked Up: " + itemsPickedUp.ToString();
		
	}
	
	void UpdateThiefVelocity() {
		 Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1.0f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dirVec = worldPos - transform.position;

        if (dirVec.magnitude > 1f) {
            rigidbody.velocity += dirVec * Time.deltaTime * moveSpeed;
            if (Mathf.Abs(Vector3.Dot(transform.right * -1f, dirVec.normalized)) > 0.01f) {
                rigidbody.angularVelocity = new Vector3(0f, 0f, Vector3.Dot(transform.right*-1f, dirVec.normalized) * turnSpeed);
            }
        }

        if (rigidbody.velocity.magnitude > maxSpeed) {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
	}
	
	void UpdateParticleTrail() {
		emitter.minSize = origParticleMinSize * (rigidbody.velocity.magnitude / maxSpeed);
        emitter.maxSize = origParticleMaxSize * (rigidbody.velocity.magnitude / maxSpeed);
        emitter.localVelocity = new Vector3(0f, origParticleLocalYSpeed * (rigidbody.velocity.magnitude / maxSpeed), 0f);
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.name == "item"){
			itemsPickedUp++;
			Destroy(other.gameObject);
			
		}
	}
}
