﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void ToMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
