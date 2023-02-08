using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
    public class ARCameraSetting : MonoBehaviour
    {
        public Toggle onFlash;
        // Start is called before the first frame update
        void Start()
        {
            var vuforia = VuforiaARController.Instance;
            vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
            vuforia.RegisterOnPauseCallback(OnPaused);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnVuforiaStarted()
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }

        private void OnPaused(bool isPaused)
        {

        }
        /// <summary>
        /// 开启/关闭闪光灯
        /// </summary>
        public void FlashTourchOn()
        {
            CameraDevice.Instance.SetFlashTorchMode(onFlash.isOn);
        }
    }
}
