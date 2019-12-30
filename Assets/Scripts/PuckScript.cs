using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PuckScript : MonoBehaviour
{
    private const string AiGoal = "AiGoal";
    private const string PlayerGoal = "PlayerGoal";
    
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rigidBody;

    public float MaxSpeed;
    
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.CompareTag(AiGoal))
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(AiScored());
            }
            else if (other.CompareTag(PlayerGoal))
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                StartCoroutine(PlayerScored());
            }
        }
    }

    private IEnumerator PlayerScored()
    {
        yield return ResetPuck();
        rigidBody.position = new Vector2(0, -1);
    }
    private IEnumerator AiScored()
    {
        yield return ResetPuck();
        rigidBody.position = new Vector2(0, 1);
    }
    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rigidBody.velocity = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, MaxSpeed);
    }
}