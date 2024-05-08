using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Transform player; // Player object
    public float initialSpeed = 5f; // Initial speed of the ball
    private bool hasPassed = false; // Flag to track if the ball has passed

    void Start()
    {
        // Launch the ball towards the player at the start
        Vector3 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = direction * initialSpeed;
    }

    void Update()
    {
        // Check if the ball has passed the player
        if (!hasPassed && transform.position.z < player.position.z)
        {
            Debug.Log("Game Over"); // Print "Game Over" to the console
            hasPassed = true; // Set the flag to true since the ball has passed
        }
    }
}
