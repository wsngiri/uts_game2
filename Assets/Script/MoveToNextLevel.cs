using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* SUBSCRIBING TO MY YOUTUBE CHANNEL: 'VIN CODES' WILL HELP WITH MORE VIDEOS AND CODE SHARING IN THE FUTURE :) THANK YOU */

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;

    // Start is called before the first frame update
    public GameObject Winning;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(SceneManager.GetActiveScene().buildIndex == 5) /* < Change this int value to whatever yourlast level build index is on your build settings */
            {
                SceneManager.LoadScene("MainMenu");
                
                //Show Win Screen or Somethin.
            }
            else
            {
                //Move to next level
                Winning.SetActive(true);
                Time.timeScale = 0f;


                //Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }

    public void NextScene() {
        SceneManager.LoadScene(nextSceneLoad);
    }

    public void SceneMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
