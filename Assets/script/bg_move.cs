using UnityEngine;
using System.Collections;

public class bg_move : MonoBehaviour {

    public float speed = 2f;
    Vector3 startpos;//开始位置
    public static bool ispaly = true;

                     // Use this for initialization
    void Start()
    {

        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ispaly)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -3.55)
            {
                transform.position = startpos;
            }
        }
            
       
            
        

    }
    

}
