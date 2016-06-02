using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    private Transform myTrans;
    private Rigidbody rigidbody;
    public float moveSpeed;
    public float jumpPower;
    public bool isAir = false;
	
	void Awake ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(h, 0f, v);

        if(Input.GetButton("Jump")&&isAir)
        {
            isAir = false;
            rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
        }

        rigidbody.AddForce(moveDir * moveSpeed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Plane")
            isAir = true;
    }
}
