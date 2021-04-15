using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Over_Panel1 : MonoBehaviour {

    public Text scoretext;
    public Button restart;
    public Button back;
    // Use this for initialization
    void Start () {
        
        gameObject.SetActive(false);
        scoretext = transform.GetChild(0).Find("score").GetComponent<Text>();
        restart = transform.GetChild(0).Find("restart").GetComponent<Button>(); //按钮赋值
        restart.onClick.AddListener(RestartButtonEvent); //委托 绑定事件
        back = transform.GetChild(0).Find("back").GetComponent<Button>(); 
        back.onClick.AddListener(BackButtonEvent); 
    }
	
	// Update is called once per frame
	void Update () {
        scoretext.text ="分数: "+ Running_Panel.score.ToString();
    }
    public void RestartButtonEvent()
    {
        gameObject.SetActive(false);
        /*GameObject.Find("Canvas/Over_Panel").GetComponent<Animator>().enabled = false;*/
        bg_move.ispaly = true;
        //audio_control.sound.Playbutton();
        //清除火圈、障碍和玩家
        Destroy(GameObject.FindGameObjectsWithTag("fire"));
        Destroy(GameObject.FindGameObjectsWithTag("Player"));
        Destroy(GameObject.FindGameObjectsWithTag("catcus"));
        //重置分数
        Running_Panel.score = 0;
        //恢复 生成所有
        
        
        GameObject.Find("Main Camera").GetComponent<Game_controller1>().Create();
        
        audio_control.sound.bgmusic.Play();
       
        Instantiate(Resources.Load("player"), new Vector2(-0.99f, -0.41f), Quaternion.identity);

        //隐藏 over_panel界面
        
    }
  

    public void BackButtonEvent()
    {
       // audio_control.sound.Playbutton();
        //隐藏自己
        gameObject.SetActive(false);
        //删除屏幕上所有
        Destroy(GameObject.FindGameObjectsWithTag("fire"));
        Destroy(GameObject.FindGameObjectsWithTag("catcus"));
        //隐藏运行界面  
        transform.parent.Find("Running_Panel").gameObject.SetActive(false);
        
        //显示开始界面
        transform.parent.Find("Start_Panel").gameObject.SetActive(true);
       
       
        
    }
    private void Destroy(GameObject[] Objects)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Destroy(Objects[i]);
        }
    }
}
