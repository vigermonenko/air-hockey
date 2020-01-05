using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    
    public int? LockedFingerId { get; set; }
    public Transform Bounder;
    public Collider2D PlayerCollider { get; private set; }
    public PlayerController Controller;
 
    private Rigidbody2D rigidBody;
    private Boundary playerBoundary;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
        playerBoundary = new Boundary(
            Bounder.GetChild(0).position.y, Bounder.GetChild(1).position.x,
        Bounder.GetChild(2).position.y, Bounder.GetChild(3).position.x
        );
    }

    private void OnEnable()
    {
        Controller.Players.Add(this);
    }

    private void OnDisable()
    {
        Controller.Players.Remove(this);
    }
    
    public void MoveToPosition(Vector2 position)
    {
        var clampedX = Mathf.Clamp(position.x, playerBoundary.Left, playerBoundary.Right);
        var clampedY = Mathf.Clamp(position.y, playerBoundary.Down, playerBoundary.Up);
        var clampedMousePosition = new Vector2(clampedX, clampedY);
        rigidBody.MovePosition(clampedMousePosition);
    }

    private Vector2 StartPosition => new Vector2(0, -3);
    public void ResetPosition()
    {
        rigidBody.position = StartPosition;
    }
}