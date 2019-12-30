using UnityEngine;
 
public class UiManager : MonoBehaviour {
 
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;
 
    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LooseTxt;
 
    [Header("Other")]
    public AudioManager audioManager;
 
    public ScoreScript scoreScript;
 
    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AiScript aiScript;
 
    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;
 
        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);
 
        if (didAiWin)
        {
            audioManager.PlayLost();
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);
        }
        else
        {
            audioManager.PlayWin();
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }
 
    public void RestartGame()
    {
        Time.timeScale = 1;
 
        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);
 
        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }
}