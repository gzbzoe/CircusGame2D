using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Start_Panel : MonoBehaviour {

    public Button startbtn;
    public Button quitbtn;

    // Use this for initialization

 
    void Start () {

        Time.timeScale = 0;

        startbtn = transform.Find("level1").GetComponent<Button>(); //按钮赋值
        startbtn.onClick.AddListener(StartButtonEvent); //委托 绑定事件
        quitbtn = transform.Find("quit").GetComponent<Button>(); //按钮赋值
        quitbtn.onClick.AddListener(QuitButtonEvent); //委托 绑定事件
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void StartButtonEvent()
    {
        player_move.level = 1;
        bg_move.ispaly = true;
        // audio_control.sound.Playbutton();
        Time.timeScale = 1;
        GameObject.Find("Audio").GetComponent<AudioSource>().enabled = true;
        audio_control.sound.bgmusic.Play();
        //开始生成火圈 障碍物
        GameObject.Find("Main Camera").GetComponent<Game_controller1>().Create();
        //生成玩家
        Instantiate(Resources.Load("player"), new Vector2(-0.99f, -0.41f), Quaternion.identity);
        //重置分数

        Running_Panel.score = 0;
        //显示运行界面
        transform.parent.Find("Running_Panel").gameObject.SetActive(true);
        //隐藏开始界面
        gameObject.SetActive(false);
    }
    void QuitButtonEvent()
    {
        //audio_control.sound.Playbutton();
       // audio_control.sound.Playbutton();
        Application.Quit();

    }
}
