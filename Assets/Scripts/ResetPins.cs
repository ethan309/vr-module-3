﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ResetPins : MonoBehaviour
{
    private GameObject[] pins;

    public int winningScore;
    public int score;

    public Text scoreDisplayText;
    public Text endgameMessage;

    // Start is called before the first frame update
    void Awake()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        endgameMessage.text = "";
    }

    void UpdateScore(int newScore)
    {
        score = newScore;
        scoreDisplayText.text = "Score: " + score.ToString();
        if (score >= winningScore)
        {
            endgameMessage.text = "Please Reset Pins";
        }
        else
        {
            endgameMessage.text = "";
        }
    }

    private void FixedUpdate()
    {
        int newScore = 0;
        foreach (GameObject pin in pins)
        {
            if (pin.GetComponent<Resetable>().hit)
            {
                newScore += 1;
            }
        }
        UpdateScore(newScore);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Triggerred");
        if (other.gameObject.CompareTag("Player"))
        {
            score = 0;
            foreach (GameObject pin in pins)
            {
                pin.GetComponent<Resetable>().ToggleReset(true);
            }
        }
    }
}