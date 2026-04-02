using UnityEngine;
using UnityEngine.InputSystem;

namespace kimjinsoo.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        private int maxhealth;
        private int currenthealth;
        [SerializeField] private HealthBar healthbar;

        private void Awake()
        {
            maxhealth = 100;
            currenthealth = maxhealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Damage(20);
            }
        }

        public void Damage(int x)
        {
            currenthealth -= x;
            healthbar.SetHealth(currenthealth);
        }
    }
}