using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coinCollider)
    {
        if(coinCollider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            sr.enabled = false;
            circle.enabled = false;

            GameControllerScript.instance.totalScore += score;

            GameControllerScript.instance.UpdateScoreText();
        }
    }
}
