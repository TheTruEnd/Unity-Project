using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField] private Button leftBtn;
    [SerializeField] private Button rightBtn;
    [SerializeField] private Button playBtn;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(eMusicName.Lobby_Music);
    }

    private void OnEnable()
    {
        playBtn.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Game");
        });
    }
}
