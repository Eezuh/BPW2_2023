using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OpenLevel(int number)
    {
        switch (number)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;

            case 2:
                SceneManager.LoadScene("Level2");
                break;

            case 3:
                SceneManager.LoadScene("Level3");
                break;

            case 4:
                SceneManager.LoadScene("MainMenu");
                break;

        }
    }
}
