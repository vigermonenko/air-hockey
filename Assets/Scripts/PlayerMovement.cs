using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    private const int leftMouseButton = 0;
    
    private bool wasJustClicked = true;
    private bool canMove;
    
    private Vector2 playerSize;
    private Rigidbody2D rigidBody;
    public Transform Bounder;

    Boundary playerBoundary;

    void Start () {
        playerSize = GetComponent<SpriteRenderer>().bounds.extents;
        rigidBody = GetComponent<Rigidbody2D>();
        playerBoundary = new Boundary(
            Bounder.GetChild(0).position.y, Bounder.GetChild(1).position.x,
        Bounder.GetChild(2).position.y, Bounder.GetChild(3).position.x
        );
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
            if (canMove)
            {
                var clampedX = Mathf.Clamp(mousePosition.x, playerBoundary.Left, playerBoundary.Right);
                var clampedY = Mathf.Clamp(mousePosition.y, playerBoundary.Down, playerBoundary.Up);
                var clampedMousePosition = new Vector2(clampedX, clampedY);
                rigidBody.MovePosition(clampedMousePosition);
            }
        }
        else {
            wasJustClicked = true;
        }
    }
}