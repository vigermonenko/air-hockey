using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Toggle ToggleMultiplayer;
    private const string game = "SampleScene";

    private void Start()
    {
        ToggleMultiplayer.isOn = GameValues.IsMultiplayer;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(game);
    }

    public void SetMultiplayer(bool isOn)
    {
        GameValues.IsMultiplayer = isOn;
    }
}
