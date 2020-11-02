using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverUI : MonoBehaviour
{

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

