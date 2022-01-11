using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Game : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void PreviousLevel()
    {
        SceneManager.LoadScene(0);
    }


}
