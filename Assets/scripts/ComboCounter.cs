﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour
{
    float countDownTime = 3f;
    Coroutine currentCountDown;
    int comboCount;
    public int maxCombo;
    public int totalComboCounter;
    [SerializeField] Text currentComboTxt;
    [SerializeField] ComboAnimationManager comboAnimManager;

    public void DoubleJumpWasTimed() 
    {
        actualize();
    }

    public void BeanJumpWasTimed() 
    {
        actualize();
    }

    public void WallJumpWasTimed() 
    {
        actualize();
    }

    public void BeanWasDestroyed()
    {
        actualize();
    }

    public void BouncedOffTheWall()
    {
        actualize();
    }

    private void actualize()
    {
        if (currentCountDown != null) StopCoroutine(currentCountDown);
        currentCountDown = StartCoroutine(actualizeCountDown());
        comboCount++;
        comboAnimManager.ReactToTimedAction(comboCount);
        currentComboTxt.text = comboCount.ToString();
        totalComboCounter ++;
    }

    private IEnumerator actualizeCountDown()
    {
        yield return new WaitForSeconds(countDownTime);
        if (comboCount > maxCombo) maxCombo = comboCount;
        comboCount = 0;
        currentComboTxt.text = comboCount.ToString();
    }
}
