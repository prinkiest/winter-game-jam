using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
