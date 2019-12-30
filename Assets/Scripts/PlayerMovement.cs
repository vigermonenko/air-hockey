using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    private const int leftMouseButton = 0;
    private bool wasJustClicked = true;
    private bool canMove;
    Vector2 playerSize;
    private Rigidbody2D rigidBody;
 
    void Start () {
        playerSize = GetComponent<SpriteRenderer>().bounds.extents;
        rigidBody = GetComponent<Rigidbody2D>();
    }
 
    void Update () {
        if (Input.GetMouseButton(leftMouseButton)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
            if (wasJustClicked) {
                wasJustClicked = false;
 
                if ((mousePosition.x >= transform.position.x && mousePosition.x < transform.position.x + playerSize.x ||
                     mousePosition.x <= transform.position.x && mousePosition.x > transform.position.x - playerSize.x) &&
                    (mousePosition.y >= transform.position.y && mousePosition.y < transform.position.y + playerSize.y ||
                     mousePosition.y <= transform.position.y && mousePosition.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else {
                    canMove = false;
                }
            }
            if (canMove) {
                rigidBody.MovePosition(mousePosition);
            }
        }
        else {
            wasJustClicked = true;
        }
    }
}