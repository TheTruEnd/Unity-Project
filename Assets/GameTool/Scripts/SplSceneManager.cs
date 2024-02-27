using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
namespace GameTool
{
    public class SplSceneManager : MonoBehaviour
    {
        public Slider slider;
        public Button continueBtn;
        public TextMeshProUGUI textContinue;

        private void Start()
        {
            StartCoroutine(nameof(LoadSceneHome));
            textContinue.gameObject.SetActive(false);
        }

        IEnumerator LoadSceneHome()
        {
            slider.DOValue(100, 2).OnComplete(() =>
            {
                textContinue.gameObject.SetActive(true);
                continueBtn.onClick.AddListener(()=>
                {
                    LoadSceneManager.Instance.LoadSceneHome();
                    AudioManager.Instance.Fade(0, 0.5f);
                });
                textContinue.DOFade(1, 0.5f).SetDelay(0.5f).SetLoops(-1, LoopType.Yoyo);
            });
            yield return new WaitForSeconds(3);
        }
    }
}