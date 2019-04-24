using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Debug.Log("Level Complete!");
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Invoke("Restart", restartDelay);
            Debug.Log("We hit something!");
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
