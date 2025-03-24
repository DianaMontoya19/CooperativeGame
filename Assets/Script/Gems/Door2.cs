using UnityEngine;

namespace Script.Gems
{
    public class Door2 : MonoBehaviour
    {
        public bool activePlayer2;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player2"))
            {
                activePlayer2 = true;
            }

        }
    }
}