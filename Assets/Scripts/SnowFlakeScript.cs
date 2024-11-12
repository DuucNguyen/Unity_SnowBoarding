using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlakeScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PlayerScore playerScore;
    [SerializeField] int scoreBonus;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScore.IncreaseScore(scoreBonus);
            playerScore.IncreaseSnowFlake();
            Destroy(gameObject);
        }
    }
}
