using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Level_change2 : MonoBehaviour
{

    public void StartLevel1()
    {
        player_move.level = 1;
        SceneManager.LoadScene("Level1");
        
    }
}
