using UnityEngine;
namespace Clock
{
    public class RotateClock : MonoBehaviour
    {
        [SerializeField] private bool akrep;
        public int rotateSpeed;
        [HideInInspector] public int speed;
        private void Start()
        {
            
            speed = rotateSpeed;
        }

        private void RotateAkrep()
        {
            transform.Rotate(0,(rotateSpeed * 0.3f) * Time.deltaTime,0);
        }

        private void RotateYelkovan()
        {
            transform.Rotate(0,rotateSpeed * Time.deltaTime,0);
        }
        private void Update()
        {
            if (akrep)
            {
                RotateAkrep();
            }
            else
            {
                RotateYelkovan();
            }
        }
        public void ReverseClocks()
        {
            rotateSpeed = rotateSpeed * -3 / 2;
        }
    }
}
