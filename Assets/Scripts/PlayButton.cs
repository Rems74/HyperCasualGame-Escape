using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
}
