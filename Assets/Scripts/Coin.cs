using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float finalXPosition;    // The final x-axis position the enemy moves towards
    public float moveSpeed = 5f;     // Speed at which the enemy moves

    void Update()
    {
        // Calculate the target position based on the final x-axis position
        Vector2 targetPosition = new Vector2(finalXPosition, transform.position.y);

        // Move the enemy towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
