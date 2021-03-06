﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutFourthBoss : MonoBehaviour {

    Animator animator;
    public static bool fadeOut = false;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3.5f);
        GameManager.beatFourthBoss = true;
        GameManager.bossMode = false;
        PlayerLife.lives = 3;
        GameManager.level = 21;
        SceneManager.LoadScene("FourthBossCutScene");
        FrontPowerCore.powerCoreHealth = 1;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (fadeOut == true)
        {
            CheckPoints.passedFourthCheckpoint = true;
            animator.SetTrigger("FadeOut");
            StartCoroutine(FadeOut());
            fadeOut = false;
        }
    }
}
