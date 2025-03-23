using System;
using Script.Platform;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Lever
{
    public class LeverController : MonoBehaviour
    {
        public static LeverController Instance;
        public bool platformActive,blockActive;
        public GameObject[] _obstacle;

        private void Start()
        {
            Instance = this;
            platformActive = false;
            

        }

        public void Update()
        {
            if (platformActive)
            {
                _obstacle[0].GetComponent<InteractPlatform>().GetAnim();
                Debug.Log("entro");
            }
            if (blockActive)
            {
                _obstacle[1].GetComponent<InteractPlatform>().GetAnim();
                Debug.Log("entroOtro");
            }
        }

       
    }
}