using System.Collections;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    private const string AiGoal = "AiGoal";
    private const string PlayerGoal = "PlayerGoal";
    
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rigidBody;
    
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
                StartCoroutine(ResetPuck());
            }
            else if (other.CompareTag(PlayerGoal))
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
    }
 
    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rigidBody.velocity = rigidBody.position = new Vector2(0, 0);
    }
}