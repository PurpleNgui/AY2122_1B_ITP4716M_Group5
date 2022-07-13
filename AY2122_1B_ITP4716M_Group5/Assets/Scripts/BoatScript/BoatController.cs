using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour
{

	public float turnSpeed = 100f;
	public float accellerateSpeed = 100f;

	private Rigidbody rbody;

	// Use this for initialization
	void Start()
	{
		rbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
		rbody.AddForce(transform.forward * v * accellerateSpeed * Time.deltaTime);


	}
}
