using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject AiPlayer;
    void Start()
    {
        if (GameValues.IsMultiplayer) {
            AiPlayer.GetComponent<PlayerMovement>().enabled = true;
            AiPlayer.GetComponent<AiScript>().enabled = false;
        }
        else {
            AiPlayer.GetComponent<PlayerMovement>().enabled = false;
            AiPlayer.GetComponent<AiScript>().enabled = true;
        }
    }

}
