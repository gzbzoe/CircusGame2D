using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {

    public  int hp = 1;
    public float force = 100f;
    private bool IsGround;
    public float speed = 2f;
    private bool IsDead=false;
    public static int level;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
      
        //控制玩家
        GetComponent<Animator>().SetBool("Run", true);
        //右移 左移 跳跃
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x > 1.3)
            {
                transform.position = new Vector3(1.3f, -0.41f, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x < -1.4)
            {
                transform.position = new Vector3(-1.4f, -0.41f, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)&&IsGround==true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up*force);
            audio_control.sound.PlayJump();
            if (transform.position.y >= 0.257)
            {
                transform.position = new Vector3(transform.position.x, 0.257f, 0);
            }
        }
   
        //鼠标
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x && 
            Input.GetMouseButton(0) && IsGround == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);
            if (transform.position.x < -1.4)
            {
                transform.position = new Vector3(-1.4f, -0.41f, 0);
            }
            if (transform.position.y >= 0.257)
            {
                transform.position = new Vector3(transform.position.x, 0.257f, 0);
            }
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= transform.position.x && 
            Input.GetMouseButton(0) && IsGround == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 80);
            if (transform.position.x > 1.3)
            {
                transform.position = new Vector3(1.3f, -0.41f, 0);
            }
            if (transform.position.y >= 0.257)
            {
                transform.position = new Vector3(transform.position.x, 0.257f, 0);
            }
        }


        if(hp==0)
        {
            /*Destroy(GameObject.FindGameObjectsWithTag("plant"));
            Destroy(GameObject.FindGameObjectsWithTag("fire"));
            Destroy(GameObject.FindGameObjectsWithTag("catcus"));*/
            //显示结束面板
            if (level == 1)
            {
                GameObject.Find("Main Camera").GetComponent<Game_controller1>().Stop();
            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<Game_controller2>().Stop();
            }
           
            
           
            GameObject.Find("Canvas").transform.Find("Over_Panel").gameObject.SetActive(true);
            GameObject.Find("Canvas/Over_Panel").GetComponent<Animator>().enabled=true;

            bg_move.ispaly = false;
            StartCoroutine(Die());
            
        }

    }
   /* private void Destroy(GameObject[] Objects)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Destroy(Objects[i]);
        }
    }*/
    IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        GameObject.Find("Canvas/Over_Panel").GetComponent<Animator>().enabled = false;
    }   
        
       
        


   
    // 跳跃限制
    //空中不能跳跃
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="ground")
        {
            IsGround = true;
            GetComponent<Animator>().SetBool("Jump", false);
        }

    }
    //空中播放跳跃动画
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            IsGround = false;
            GetComponent<Animator>().SetBool("Jump", true);
            audio_control.sound.PlayJump();
        }

    }


    //触发器
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.tag=="fire")
        {
            //死亡
            //销毁刚体
            //死亡动画
            //死亡声音
            IsDead = true;
            hp--;
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            GetComponent<Animator>().SetBool("Die", true);
            audio_control.sound.PlayDie();
        }
        if (col.gameObject.tag == "plant")
        {
            
            IsDead = true;
            hp--;
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            GetComponent<Animator>().SetBool("Die", true);
            audio_control.sound.PlayDie();
        }

        if (col.gameObject.tag == "catcus")
        {
            --Running_Panel.score;
            audio_control.sound.PlayCol();
        }
        if (col.gameObject.tag == "coin" && IsDead != true)
        {
            Running_Panel.score+=2;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "pass"&&IsDead!=true)
        {
           
            Running_Panel.score++;
            
        }

    }
}
