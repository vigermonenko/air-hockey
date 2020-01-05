using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public List<PlayerMovement> Players = new List<PlayerMovement>();
    
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++) {
            Vector2 touchWorldPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            Players.ForEach(player =>
            {
                if (player.LockedFingerId == null) {
                    if (Input.GetTouch(i).phase == TouchPhase.Began &&
                        player.PlayerCollider.OverlapPoint(touchWorldPosition)) {
                        player.LockedFingerId = Input.GetTouch(i).fingerId; 
                    }
                }
                else if (player.LockedFingerId == Input.GetTouch(i).fingerId) {
                    player.MoveToPosition(touchWorldPosition);
                    if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled) {
                        player.LockedFingerId = null;
                    }
                }
            });
        }
    }
}
