using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    private Transform myTrans;
    private CharacterController player;
    public float moveSpeed;
    public float turnSpeed;
    public float jumpSpeed;
    public float gravity;

    private Vector3 moveDir = Vector3.zero;
	
	void Awake () {
        myTrans = GetComponent<Transform>();
        player = GetComponent<CharacterController>();
	}
	
	void Update () {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 rotDir = new Vector3(0f, h, 0f);
        myTrans.Rotate(rotDir * turnSpeed * Time.deltaTime);

        moveDir = myTrans.forward * v * moveSpeed + new Vector3(0, moveDir.y, 0);
        if(player.isGrounded)
        {
            moveDir.y = 0f;
            if(Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        player.Move(moveDir * Time.deltaTime);
        Debug.Log(moveDir.y);
	}
}