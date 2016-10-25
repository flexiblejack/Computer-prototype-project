using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public float smooth = 1f;
	public Rigidbody rb;

	float angle = 90.0f;
	Quaternion targetRotation; 
	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		rb = GetComponent<Rigidbody> (); 
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			print ("D key was pressed");
			targetRotation *= Quaternion.AngleAxis(angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector3.zero;

		}
		if (Input.GetKeyDown (KeyCode.A)) {
			print ("A key was pressed");
			targetRotation *= Quaternion.AngleAxis(-angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector3.zero;

		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}

	void OnTriggerCollider(Collider other){
		if (other.tag == "Ground") {
			rb.velocity = Vector3.zero;
			print ("Hit ground");
		}
	}
}
