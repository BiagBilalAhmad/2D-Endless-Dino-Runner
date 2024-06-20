using UnityEngine;

[System.Serializable]
public class ParallaxBackground : MonoBehaviour
{
    public float MoveSpeed = 1f;
    
    public float Offset;
    Vector2 startPosition;

    float NextPosition;


    private void Start()
    {
        startPosition = transform.position;

        
    }
    private void Update()
    {
        if(GameManager.Instance.StartGame)
        {
            NextPosition = Mathf.Repeat(Time.time * -MoveSpeed, Offset);
            transform.position = startPosition + Vector2.right * NextPosition;
        }
      
    }
}
