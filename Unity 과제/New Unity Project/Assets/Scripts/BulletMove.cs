using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public float moveSpeed = 10f;
    public float destroyTime = 2f;
    Transform myTrans;

	// Use this for initialization
	void Awake () {
        myTrans = GetComponent<Transform>();
        Destroy(gameObject, 3f); //3초 뒤 오브젝트가 사라짐
	}
	
	// Update is called once per frame
	void Update () {
        myTrans.Translate(0f, 0f, -moveSpeed * Time.deltaTime);
	}
}
/*총알을 계속 씬안에 둘 수 없으니 사용하는 것이 프리펩(Prefabs)
Bullet 안에 BulletMove 스크립트를 넣음 -> Prefabs폴더안에 총알 오브젝트를 넣고
Spawn을 생성함*/