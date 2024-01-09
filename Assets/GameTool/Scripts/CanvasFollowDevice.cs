using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameTool
{
    [ExecuteInEditMode]
    public class CanvasFollowDevice : MonoBehaviour
    {
        [SerializeField] private RectTransform mainRect;
        [SerializeField] private CanvasScaler scaler;
        [SerializeField] private Camera cam;
        [SerializeField] private float aspect;
        [SerializeField] private float refAspect;

        [Space] [Header("CAM SIZE")] [SerializeField]
        private float ourCamSize = 8;

        [SerializeField] private bool protectHorizontal;

        private void Awake()
        {
            ChangeAll();
        }

        private void OnEnable()
        {
            ChangeAll();
        }

        private void Start()
        {
            ChangeAll();
        }

        private void ChangeAll()
        {
            if (!mainRect)
            {
                mainRect = GetComponent<RectTransform>();
            }

            if (!scaler)
            {
                scaler = GetComponent<CanvasScaler>();
            }

            if (!cam)
            {
                cam = Camera.main;
            }

            aspect = (float) Screen.width / Screen.height; // x / y
            refAspect = scaler.referenceResolution.x / scaler.referenceResolution.y;
            ChangeScaler();
            ChangeCamSize();
        }

#if UNITY_EDITOR
        private void OnGUI()
        {
            if (!mainRect)
            {
                mainRect = GetComponent<RectTransform>();
            }

            if (!scaler)
            {
                scaler = GetComponent<CanvasScaler>();
            }

            if (!cam)
            {
                cam = FindObjectOfType<Camera>();
            }
            
            aspect = (float) Screen.width / Screen.height; // x / y
            refAspect = scaler.referenceResolution.x / scaler.referenceResolution.y;
            ChangeScaler();
            ChangeCamSize();
        }
#endif

        public void ChangeScaler()
        {
            scaler.matchWidthOrHeight = aspect < refAspect ? 0 : 1;
        }

        public void ChangeCamSize()
        {
            if (protectHorizontal && aspect < refAspect)
            {
                cam.orthographicSize = ourCamSize / (aspect / refAspect);
            }
        }
    }
}