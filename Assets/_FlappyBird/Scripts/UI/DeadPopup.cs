using System;
using GameTool;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class DeadPopup : SingletonUI<DeadPopup>
{
    public Button playAgainBtn;
    public Button chooseBirdBtn;

    private void OnEnable()
    {
        playAgainBtn.onClick.AddListener(()=>
        {
            LoadSceneManager.Instance.LoadScene("Game");
            Time.timeScale = 1;
        });
        chooseBirdBtn.onClick.AddListener(()=>
        {
            LoadSceneManager.Instance.LoadScene("Choose Bird");
            Time.timeScale = 1;
        });
    }
}
