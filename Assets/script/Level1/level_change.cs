using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class level_change : MonoBehaviour {

	public void StartLevel2()
    {
        player_move.level = 2;
        bg_move.ispaly = true;
        SceneManager.LoadScene("Level2");
    }
}
