using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RandomPatrol : MonoBehaviour
{

  
    public float minX;//-12
    public float maxX;//12
    public float minY;//-10.48
    public float maxY;//-0.28

    Vector2 targetPosition;

    public float minSpeed;
    public float maxSpeed;

    private float speed;

    public float secondToMaxDifficulty;

    // Start is called before the first frame update
    
    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed,maxSpeed,GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX,randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planets")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    float GetDifficultyPercent()
    {
        //clamp01 secure that the operation is in the arrange betweeen 0 and 1
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondToMaxDifficulty);
    }


}
