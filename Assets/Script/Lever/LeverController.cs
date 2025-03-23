using System;
using System.Collections;
using Script.Gems;
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
        public int countPlayer;
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
               
            }
            if (blockActive)
            {
                _obstacle[1].GetComponent<InteractPlatform>().GetAnim();
               
            }
        }
        

       
    }
}