using UnityEngine;
using System.Collections;

public class Game_controller1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
       


    }
    public void Create()
    {
        InvokeRepeating("ProduceFire1", 2, 5);
        InvokeRepeating("ProduceBlock", 6, 15);
        InvokeRepeating("ProduceFireCoin", 10, 20);
    }
    public void Stop()
    {
        CancelInvoke("ProduceFire1");
        CancelInvoke("ProduceBlock");
        CancelInvoke("ProduceFireCoin");
    }

    // Update is called once per frame
    void Update () {
	
	}
    //火圈
    public void ProduceFire1()
    {
        GameObject go = Instantiate(Resources.Load("firecircle")) as GameObject;
       
        //transform.GetChild(1) 获取孩子
        go.transform.position =GameObject.Find("pos").GetComponent<Transform>().position;

    }
    //带金币火圈
    public void ProduceFireCoin()
    {
        GameObject go = Instantiate(Resources.Load("firecircle2")) as GameObject;
        
        //transform.GetChild(1) 获取孩子
        go.transform.position = GameObject.Find("pos").GetComponent<Transform>().position;

    }
    //地上障碍物
    public void ProduceBlock()
    {
        GameObject go = Instantiate(Resources.Load("catcus")) as GameObject;
       
        //transform.GetChild(1) 获取孩子
        go.transform.position = GameObject.Find("block_pos").GetComponent<Transform>().position;

    }
}
