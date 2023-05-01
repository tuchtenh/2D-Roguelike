using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject gameOverUI;

    private void OnEnable()
    {
        PlayerCombat.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        PlayerCombat.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void OnMainMenuClicked()
    {
        DataPersistenceManager.instance.NewGame();
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void EnableGameOverMenu()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


}
