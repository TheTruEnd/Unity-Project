using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Loading : MonoBehaviour
{
    private int maxWidth = 1600;
    public Image yellowBar;
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        yellowBar.rectTransform.DOSizeDelta(new Vector2(maxWidth, yellowBar.rectTransform.sizeDelta.y), 5).SetEase(Ease.Linear).OnComplete(
            () => { LoadSceneManager.Instance.LoadScene("Choose Bird"); });

        loadingText.color = new Color();
        DOTween.To(value => loadingText.text = "Loading..." + (int)value + "%", 1, 100, 5).SetEase(Ease.Linear);
    }
    
}
