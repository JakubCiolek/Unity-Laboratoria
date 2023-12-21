using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // References to game objects in the hierarchy
    public GameObject EndPanel;
    public GameObject DrawCard;
    public GameObject HUD;
    public GameObject Card1;
    public GameObject NickName;

    public TMP_Text gameoverText;

    // The Start method is called before the first frame update
    void Start()
    {
        // Initially hide the end panel
        EndPanel.SetActive(false);
    }

    // The Update method is called once per frame
    void Update()
    {
        // No implementation here
    }

    // Handles the "Exit Game" button
    public void HandleExitButtonClick()
    {
        // Show the end panel
        EndPanel.SetActive(true);

        // Hide other game elements
        DrawCard.SetActive(false);
        HUD.SetActive(false);
        Card1.SetActive(false);
        NickName.SetActive(false);
    }

    // Restarts the game
    public void RestartGame()
    {
        // Get the index of the current scene and reload it
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void Win()
    {
        EndPanel.SetActive(true);
        DrawCard.SetActive(false);
        HUD.SetActive(false);
        Card1.SetActive(false);
        NickName.SetActive(false);
        gameoverText.text = "YOU WON!";
    }

    public void Defeat()
    {
        EndPanel.SetActive(true);
        DrawCard.SetActive(false);
        HUD.SetActive(false);
        Card1.SetActive(false);
        NickName.SetActive(false);
        gameoverText.text = "GAME OVER";
    }

    // Exits the game
    public void ExitGame()
    {
        // Check if the game is running in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Otherwise, use Application.Quit() to exit the game
        Application.Quit();
#endif
    }
}
