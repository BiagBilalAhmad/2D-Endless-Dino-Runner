using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    public ParallaxBackground[] parallaxBackgrounds;

    public float timer;

    public int multiplierCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        parallaxBackgrounds = GetComponentsInChildren<ParallaxBackground>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.StartGame)
        {
            timer += Time.deltaTime;

            if(Mathf.Abs(timer) > 10 && multiplierCount < 1)
            {
                foreach (var item in parallaxBackgrounds)
                {
                    item.MoveSpeed *= 1.5f;
                }
                multiplierCount++;
            }

            if (Mathf.Abs(timer) > 60 && multiplierCount < 2)
            {
                foreach (var item in parallaxBackgrounds)
                {
                    item.MoveSpeed *= 1.33f;
                }
                multiplierCount++;
            }

            if (Mathf.Abs(timer) > 90 && multiplierCount < 3)
            {
                foreach (var item in parallaxBackgrounds)
                {
                    item.MoveSpeed *= 1.25f;
                }
                multiplierCount++;
            }

            if (Mathf.Abs(timer) > 120 && multiplierCount < 4)
            {
                foreach (var item in parallaxBackgrounds)
                {
                    item.MoveSpeed *= 1.2f;
                }
                multiplierCount++;
            }
        }
    }
}
