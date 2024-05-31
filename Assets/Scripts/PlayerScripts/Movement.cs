using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Movement : MonoBehaviour
{
    public Camera Cam1;
    public Camera Cam2;
    public float speed = 2;
    public float rotateSpeed = 300;
    public GameObject leftWheel;
    public GameObject rightWheel;
    private Rigidbody rb;
    private float pushForce;
	private Vector3 pushDir;
    public float gravity = 10.0f;
    public GameObject FireEffect;


    void Update(){
        rb = GetComponent<Rigidbody>();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Cam1.gameObject.SetActive(true);
            Cam2.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(true);
        }
    }


    public void HitPlayer(Vector3 velocityF, float time)
	{
		rb.velocity = velocityF;

		pushForce = velocityF.magnitude;
		pushDir = Vector3.Normalize(velocityF);
		StartCoroutine(Decrease(velocityF.magnitude, time));
	}

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, z, 0);
        Vector3 rotationToAdd = new Vector3(0, 0, x);
        transform.Translate(movement * speed * Time.deltaTime);
        transform.Rotate(rotationToAdd);

        /*
        // Поворот колес
        Vector3 rotationWheelRight = new Vector3(0, 0, z);
        Vector3 rotationWheelLeft = new Vector3(0, 0, -z);
        leftWheel.transform.Rotate(rotationWheelLeft);
        rightWheel.transform.Rotate(rotationWheelRight);

        Vector3 rotationWheelRightRotate = new Vector3(0, 0, -x);
        Vector3 rotationWheelLeftRotate = new Vector3(0, 0, x);
        leftWheel.transform.Rotate(rotationWheelLeftRotate);
        rightWheel.transform.Rotate(rotationWheelRightRotate);
        */

    }

    	private IEnumerator Decrease(float value, float duration)
	    {
		float delta = 0;
		delta = value / duration;

		    for (float t = 0; t < duration; t += Time.deltaTime)
		    {
			    yield return null;
			    pushForce = pushForce - Time.deltaTime * delta;
			    pushForce = pushForce < 0 ? 0 : pushForce;
			    }
			rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0)); //Add gravity
		}
}