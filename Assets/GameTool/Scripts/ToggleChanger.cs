using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameTool
{
    public class ToggleChanger : MonoBehaviour
    {
        [SerializeField] private Image bgOffImage;
        [SerializeField] private Image bgOnImage;
        [SerializeField] private Image handle;
        [SerializeField] private Image handleOn;
        [SerializeField] private Toggle toggle;
        [SerializeField] private Vector2 onPos;
        [SerializeField] private Vector2 offPos;

        private bool isSpawned;

        private void OnValidate()
        {
            toggle = GetComponent<Toggle>();
        }

        private void Start()
        {
            isSpawned = true;
        }

        public void OnValueChanged()
        {
            if (!isSpawned)
            {
                if (toggle.isOn)
                {
                    bgOnImage.color = Color.white;
                    bgOffImage.color = new Color(1, 1, 1, 0);
                    handle.rectTransform.anchoredPosition = onPos;
                    handleOn.color = Color.white;
                }
                else
                {
                    bgOnImage.color = new Color(1, 1, 1, 0);
                    bgOffImage.color = new Color(1, 1, 1, 0);
                    handle.rectTransform.anchoredPosition = offPos;
                    handleOn.color = new Color(1, 1, 1, 0);
                }

                isSpawned = true;
                return;
            }

            if (toggle.isOn)
            {
                bgOnImage.DOFade(1, 0.2f);
                bgOffImage.DOFade(0, 0.1f).SetDelay(0.1f);
                handle.rectTransform.DOAnchorPos(onPos, 0.25f);
                handleOn.DOFade(1, 0.25f);
            }
            else
            {
                bgOnImage.DOFade(0, 0.2f);
                bgOffImage.DOFade(1, 0.1f).SetDelay(0.1f);
                handle.rectTransform.DOAnchorPos(offPos, 0.25f);
                handleOn.DOFade(0, 0.25f);
            }
        }
    }
}