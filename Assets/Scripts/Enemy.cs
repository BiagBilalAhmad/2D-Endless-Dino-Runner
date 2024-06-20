using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float finalXPosition;    // The final x-axis position the enemy moves towards
    public float moveSpeed = 5f;     // Speed at which the enemy moves

    void Update()
    {
        // Calculate the target position based on the final x-axis position
        Vector2 targetPosition = new Vector2(finalXPosition, transform.position.y);

        // Move the enemy towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the target position
        if (Mathf.Approximately(transform.position.x, finalXPosition))
        {
            // Destroy the enemy when it reaches the target position
            Destroy(gameObject);
        }
    }
    public void DefeatEnemy()
    {
        // Handle enemy defeat logic, e.g., play an animation, particle effects, etc.
        Destroy(gameObject);
    }
}
