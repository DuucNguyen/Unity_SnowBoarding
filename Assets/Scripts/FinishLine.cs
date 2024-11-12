using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Canvas gameOverPanel;
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] GameObject player;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("DisplayGameOverPanel", delayTime); 
        }
    }

    void DisplayGameOverPanel() //Created reload scene method in order to use invoke
    {
        gameOverPanel.enabled = true;
        if (player == null) return;
        Invoke("DestroyPlayer", delayTime);
    }
    void DestroyPlayer()
    {
        Destroy(player);
    }


}
