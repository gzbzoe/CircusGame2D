using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Running_Panel : MonoBehaviour {

    public Sprite paused;//zanting图片
    public Sprite start; //恢复图片
    public Text scoreText;
    public static int score = 0;
    bool IsRunning = true;
    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
        scoreText = transform.Find("score").GetComponent<Text>();
        scoreText.text = "分数：" + score.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.text = "分数：" + score.ToString();
    }
    public void PauseButtonEvent()   //开始
    {
        //Time.timeScale = 0;  游戏静止
        //开始游戏
        //开始按钮隐藏 停止按钮显示

        //一个物体隐藏
        
        if (IsRunning)
        {
            audio_control.sound.bgmusic.Stop();
            IsRunning = false;
            Time.timeScale = 0;
            //GameObject.Find("Canvas/running_panel/pause").GetComponent<Button>();
            transform.Find("pause").GetComponent<Image>().sprite = start;
            /*GameObject.Find("Audio").GetComponent<AudioSource>().Stop();*/
        }
        else
        {
            audio_control.sound.bgmusic.Play();
            
            IsRunning = true;
            Time.timeScale = 1;
            transform.Find("pause").GetComponent<Image>().sprite = paused;
            /*GameObject.Find("Audio").GetComponent<AudioSource>().Play();*/
        }

        //一个物体显示


    }
}
