using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasHandler : MonoBehaviour
{
    private TMP_Text scoreKeeper;
    public static int score = 0;
    void Start()
    {
        scoreKeeper = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        scoreKeeper.text = "Score " + score;
    }
   
}
