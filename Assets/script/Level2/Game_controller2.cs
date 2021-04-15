using UnityEngine;
using System.Collections;

public class Game_controller2 : MonoBehaviour {

    void Start()
    {
        Time.timeScale = 1;
        GameObject.Find("Audio").GetComponent<AudioSource>().enabled = true;
        
        //开始生成plant和金币
       Create();
        //生成玩家
        Instantiate(Resources.Load("player"), new Vector2(-0.99f, -0.41f), Quaternion.identity);
       

        Running_Panel.score = 0;
        //显示运行界面
        GameObject.Find("Canvas").transform.Find("Running_Panel").gameObject.SetActive(true);


    }
    void Update()
    {

    }
    public void Create()
    {
        InvokeRepeating("ProducePlant", 2, 6);
        InvokeRepeating("ProduceCoin", 3, 15);

    }
     public void Stop()
     {
         CancelInvoke("ProducePlant");
         CancelInvoke("ProduceCoin");
     }

 
    public void ProducePlant()
    {
        GameObject go = Instantiate(Resources.Load("plant")) as GameObject;
       
        //transform.GetChild(1) 获取孩子
        go.transform.position = GameObject.Find("block_pos").GetComponent<Transform>().position;

    }
    public void ProduceCoin()
    {
        GameObject go = Instantiate(Resources.Load("coin")) as GameObject;
       
        //transform.GetChild(1) 获取孩子
        go.transform.position = GameObject.Find("coin_pos").GetComponent<Transform>().position;

    }

}

