using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    TextMeshProUGUI score;

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

}
