using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	[HideInInspector] public float smooth = 1.0f;
	public float jumpSpeed = 10.0f;
	[HideInInspector] public static Rigidbody2D rb;
	[HideInInspector] public static float gravityScale = 15.0f;
	[HideInInspector] public static float moveSpeed = 2.0f;
	[HideInInspector] public static int orientationPlayer = 0;

	[HideInInspector] public static Vector3[] directionPlayerList = new Vector3[4]{new Vector3(1, 0,0),new Vector3(0,1,0),new Vector3(-1,0,0),new Vector3(0,-1,0)}; 
	[HideInInspector] public static Vector3[] directionJumpList = new Vector3[4]{new Vector3(0, 1,0),new Vector3(-1,0,0),new Vector3(0,-1,0),new Vector3(1,0,0)}; 
	[HideInInspector] public static Vector3 directionPlayer;

	float angle = 90.0f;
	[HideInInspector] public static bool jumping = true;
	Quaternion targetRotation; 
	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;

		rb = GetComponent<Rigidbody2D> (); 
		rb.gravityScale = gravityScale;
		directionPlayer = directionPlayerList [orientationPlayer];
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.D)) {
			if (orientationPlayer >= 3) {
				orientationPlayer = 0;
			}
			else{
				orientationPlayer += 1;
			};
			targetRotation *= Quaternion.AngleAxis(angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector2.zero;
			rb.gravityScale = gravityScale;
			jumping = true;

		}
		if (Input.GetKeyDown (KeyCode.A)) {
			if (orientationPlayer <= 0) {
				orientationPlayer = 3;
			}
			else{
				orientationPlayer -= 1;
			};
			targetRotation *= Quaternion.AngleAxis(-angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector2.zero;
			rb.gravityScale = gravityScale;
			jumping = true;

		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= directionPlayerList [orientationPlayer] * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += directionPlayerList [orientationPlayer] * Time.deltaTime * moveSpeed;
		}
		if (Input.GetKey (KeyCode.UpArrow) && !jumping) {
			Jump ();
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}

	void Jump(){
		rb.AddForce (directionJumpList [orientationPlayer] * Time.deltaTime * jumpSpeed);
		jumping = true;
		rb.gravityScale = gravityScale;

	} 
}