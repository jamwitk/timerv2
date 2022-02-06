using System;
using Audio;
using Game;
using Score;
using UnityEngine;

namespace Player
{
    public class PlayerTrigger : MonoBehaviour
    {
    
        public Player _player;
        private MaterialManager _materialManager;
        private ScoreManager _scoreManager;
        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _materialManager = FindObjectOfType<MaterialManager>();
        }

        private void OnCollisionEnter(Collision other)
        {
            _player.isGrounded = true;
            _player.isJumpedToPlane = other.gameObject.tag switch
            {
                "12Planes" => true,
                _ => _player.isJumpedToPlane
            };
        }
        private void OnTriggerEnter(Collider other)
        {
            _player.isGrounded = true;
            switch (other.gameObject.tag)
            {
                case "12Planes":
                {
                    _player.isJumpedToPlane = true;

                    if (other.gameObject.name == "12Plane"+_materialManager.random)
                    {
                        GameManager.instance.PlayParticle();

                        GameManager.instance.particle.transform.position = transform.position;

                        StartCoroutine(GameManager.instance.StopParticle());
                    
                        AudioManager.Instance.Play("JumpPlane");
                        
                        _materialManager.planes[_materialManager.random].GetComponent<ChangeMaterial>().SetToDefault();

                        if (_player.isJumpedToPlane)
                        {
                            _materialManager.SetNewTarget();
                            _player.isJumpedToPlane = false;

                        }
                        
                        _scoreManager.ScoreCombo++;
                        
                        _scoreManager.ScoreCalculation();
                    }
                    break;
                }
            }
        }
    }
}
