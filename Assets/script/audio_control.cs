using UnityEngine;
using System.Collections;

public class audio_control : MonoBehaviour {

    public static audio_control sound;
    public AudioSource bgmusic;
    public AudioClip jump;
    public AudioClip die;
    public AudioClip gameover;
    public AudioClip clickbutton;
    // Use this for initialization
    void Start () {
        //获得这个脚本
        sound = this;
        bgmusic = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    //jump音效
    public void PlayJump()
    {
       
        bgmusic.PlayOneShot(jump);
    }
   /* public void Playbutton()
    {
        
        bgmusic.PlayOneShot(clickbutton);
        
    }*/
    //碰撞音效
    public void PlayCol()
    {
        bgmusic.Stop();
        bgmusic.PlayOneShot(die);
        bgmusic.Play();
    }
    //死亡音效
    public void PlayDie()
    {
        bgmusic.Stop();
        bgmusic.PlayOneShot(die);
        StartCoroutine(PlayGameOver());
    }
    //游戏结束音效
    IEnumerator PlayGameOver()
    {
        yield return new WaitForSeconds(1f);
        bgmusic.PlayOneShot(gameover);
    }
}
