using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{


    [SerializeField] AudioSource audioSourse;
    [SerializeField] AudioClip bonusSound;
    [SerializeField] AudioClip decreaseBonusSound;

    [SerializeField] Text snowFlakeDisplay;

    //[SerializeField] Text snowFlakeDisplayResult;

    int score;
    public int snowFlake;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        snowFlake = 0;
        audioSourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        snowFlakeDisplay.text = score.ToString();
    }

    public int GetScore()
    {
        return this.score;
    }

    public void IncreaseScore(int value)
    {
        //play sound
        audioSourse.PlayOneShot(bonusSound);
        score += value;
    }

    public void IncreaseSnowFlake()
    {
        snowFlake += 1;
    }

    public void DecreaseScore(int value)
    {
        audioSourse.PlayOneShot(decreaseBonusSound);
        score -= value;
    }


}
