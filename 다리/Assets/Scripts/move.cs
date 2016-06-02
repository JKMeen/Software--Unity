using UnityEngine;
using System.Collections;

public class MNewBehaviourScript : MonoBehaviour
{
    private Transform myTrans;
    private float v;
    private float h;

    public float moveSpeed;
    public float turnSpeed;

    // Use this for initialization
    void Awake()
    {
        myTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(0f, v, 0f);
        myTrans.Translate(moveDir * moveSpeed * Time.deltaTime);

        myTrans.Rotate(0f, 0f, -h * turnSpeed * Time.deltaTime);
    }
}
