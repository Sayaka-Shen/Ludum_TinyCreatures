using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void Retry()
    {
        GameManager.Instance.GameState = GameState.StartScreen;
        UIManager.Instance.DestroyManager();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
