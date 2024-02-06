using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void toGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void toStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
    public void quitApplication()
    {
        Application.Quit();
    }
}
