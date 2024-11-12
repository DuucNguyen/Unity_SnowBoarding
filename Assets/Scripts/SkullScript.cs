using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
    // Start is called before the first frame update
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float speed;
    [SerializeField] PlayerScore playerScore;

    void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("IncreaseSpeed", 1, 1);
    }
    private void FixedUpdate()
    {
        surfaceEffector2D.speed = speed;
    }

    void IncreaseSpeed()
    {
        speed += 10f;
        speed = Mathf.Clamp(speed, 40f, 60f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScore.DecreaseScore(200);
        }
    }

}
