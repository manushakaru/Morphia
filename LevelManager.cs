using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    public static LevelManager Instance{set;get;}

    private int hitpoint = 3;
    private int score =0;

    public Vector3 spawnPosition;
    public Transform playerTransform;

    public Text scoreText;
    public Text hitpointText;

    private void Awake()
    {
        Instance = this;
        scoreText.text = "Current score : " + score.ToString();
        hitpointText.text = "Hitpoint : " + hitpoint.ToString();
    }

    private void update ()
    {
        if(playerTransform.position.y < -10)
        {
            playerTransform.position = spawnPosition;
            hitpoint --;
            hitpointText.text = "Hitpoint : " + hitpoint.ToString();
            if (hitpoint <= 0)
            {
                Application.LoadLevel("Menu");
            }
        }
    }

    public void Win()
    {
        if(score > PlayerPrefs.GetInt("PlayerScore"))
        {
            PlayerPrefs.SetInt("PlayerScore", score);
            
        }

        Application.LoadLevel("Menu");
    }

    public void CollectCoin()
    {
        score++;
        scoreText.text = "Current score : " + score.ToString();
    }
}