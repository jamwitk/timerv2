using System;
using Game;
using UnityEngine;

namespace Clocks
{
    public class ClockController : MonoBehaviour
    {
        [SerializeField] private Clock[] clocks;
        [SerializeField] private float reverseSpeed;
        public  float[] speeds = new float[2];

        private void Start()
        {
            if (clocks.Length > 0)
            {
                for (int i = 0; i < clocks.Length; i++)
                {
                    speeds[i] = clocks[i].speed;
                }
            }
        }

        public void SetClocksRotationDefault()
        {
            if (clocks.Length <= 0) return;
            foreach (var clock in clocks)
            {
                clock.transform.rotation = Quaternion.Euler(Vector3.zero);
            }
        }
        public void SetClocksSpeedDefault()
        {
            if (clocks.Length <= 0) return;
            for (int i = 0; i < clocks.Length; i++)
            {
                clocks[i].speed = speeds[i] ;
            }
        }

        public void ReverseAndAddSpeedClocksDirection()
        {
            foreach (var clock in clocks)
            {
                clock.speed *= reverseSpeed;
            }
        }
        private void RotateClock()
        {
            if (clocks.Length>0)
            {
                foreach (var clock in clocks)
                {
                    clock.transform.Rotate(0,clock.speed*Time.deltaTime,0);
                }   
            }
        }
        private void Update()
        {
            if (!GameManager.instance.isGame) return;
            RotateClock();
        }
        
    }
}
