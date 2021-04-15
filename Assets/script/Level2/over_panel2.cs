using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class over_panel2 : MonoBehaviour {

    public Text scoretext;
    public Button restart;
    public Button back;
    // Use this for initialization
    void Start()
    {

        gameObject.SetActive(false);
        scoretext = transform.GetChild(0).Find("score").GetComponent<Text>();
        restart = transform.GetChild(0).Find("restart").GetComponent<Button>(); //按钮赋值
        restart.onClick.AddListener(RestartButtonEvent); //委托 绑定事件
       /* back = transform.GetChild(0).Find("back").GetComponent<Button>();
        back.onClick.AddListener(BackButtonEvent);*/
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "分数: " + Running_Panel.score.ToString();
    }
    public void RestartButtonEvent()
    {
        
        //清除障碍
        bg_move.ispaly = true;
        //audio_control.sound.Playbutton();
        Destroy(GameObject.FindGameObjectsWithTag("catcus"));
        Destroy(GameObject.FindGameObjectsWithTag("coin"));
        Destroy(GameObject.FindGameObjectsWithTag("plant"));
        //重置分数
        Running_Panel.score = 0;
        //恢复 生成障碍
        Time.timeScale = 1;

        GameObject.Find("Main Camera").GetComponent<Game_controller2>().Create();

        audio_control.sound.bgmusic.Play();
        //生成玩家
        Instantiate(Resources.Load("player"), new Vector2(-0.6f, -0.41f), Quaternion.identity);

        //隐藏 over_panel界面
        gameObject.SetActive(false);
    }
    private void Destroy(GameObject[] Objects)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Destroy(Objects[i]);
        }
    }

   /* public void BackButtonEvent()
    {
        //隐藏运行界面  parent相当于transform类型 因此可以用Find（）
        gameObject.SetActive(false);
        Destroy(GameObject.FindGameObjectsWithTag("fire"));
        Destroy(GameObject.FindGameObjectsWithTag("Player"));
        transform.parent.Find("Running_Panel").gameObject.SetActive(false);

        //显示开始界面
        transform.parent.Find("Start_Panel").gameObject.SetActive(true);
        //隐藏结束界面

        //重置分数


    }*/
}
