using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour 
{
    private int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("PlayerScore");

    }

    public void ToGame()
    {
        Application.LoadLevel("Gym");
    }
}
