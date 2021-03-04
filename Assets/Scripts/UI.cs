using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image bar;
    public PlayerMovement playerMovement;
    public float maxTime;
    public float currentTime;

    void Update()
    {
        currentTime = playerMovement.freezeCounter;
        maxTime = playerMovement.freezeResetTime;
        bar.fillAmount = currentTime / maxTime;
    }
}
