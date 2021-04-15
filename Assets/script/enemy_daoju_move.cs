using UnityEngine;
using System.Collections;

public class enemy_daoju_move : MonoBehaviour {

    public float speed = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
       
        //出屏幕销毁
        if(gameObject.tag=="fire")
        {
            
            if (transform.position.x < -1.83)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (gameObject.tag == "catcus")
        {
            if (transform.position.x < -1.83)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (gameObject.tag == "plant")
        {

            if (transform.position.x < -1.83)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (gameObject.tag == "coin")
        {

            if (transform.position.x < -1.83)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}
