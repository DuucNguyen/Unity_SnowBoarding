using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] ParticleSystem crashEffect;

    public bool hasCrashed = false;

    [SerializeField] AudioClip crashSFX;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            InvokeDie();
        }
    }

    public void InvokeDie()
    {
        Invoke("Die", 0.5f);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
