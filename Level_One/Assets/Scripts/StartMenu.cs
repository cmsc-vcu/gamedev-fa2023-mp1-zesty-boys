using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
