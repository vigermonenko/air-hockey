using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    private const int leftMouseButton = 0;
    private Vector2 StartPosition => new Vector2(0, -3);
    
    private bool wasJustClicked = true;
    private bool canMove;
    
    private Rigidbody2D rigidBody;
    public Transform Bounder;
    public Collider2D playerCollider;
    
    Boundary playerBoundary;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerBoundary = new Boundary(
            Bounder.GetChild(0).position.y, Bounder.GetChild(1).position.x,
        Bounder.GetChild(2).position.y, Bounder.GetChild(3).position.x
        );
    }
 
    void Update () {
        if (Input.GetMouseButton(leftMouseButton)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
            if (wasJustClicked)
            {
                wasJustClicked = false;

                canMove = playerCollider.OverlapPoint(mousePosition);
            }
            if (canMove) {
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

    public void ResetPosition()
    {
        rigidBody.position = StartPosition;
    }
}