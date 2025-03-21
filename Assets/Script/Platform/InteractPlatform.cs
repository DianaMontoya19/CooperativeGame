using UnityEditor.Search;
using UnityEngine;

namespace Script.Platform
{
    public class InteractPlatform : MonoBehaviour
    {
        public bool activatePlatform;
        [SerializeField] private Animator anim;

        public void ActivateAnim()
        {
            anim.enabled = true;
        }
    }
}