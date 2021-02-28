using Game;
using Score;
using UnityEngine;

namespace Player
{
    public class PlayerTrigger : MonoBehaviour
    {
    
        private Player _player;
        private MaterialManager _materialManager;
        private ScoreManager _scoreManager;
        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _materialManager = FindObjectOfType<MaterialManager>();
            _player = GetComponent<Player>();
        }

        private void OnCollisionEnter(Collision other)
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
                        
                        _materialManager.SetNewTarget();
                        
                        _scoreManager.ScoreCombo++;
                        
                        _scoreManager.ScoreCalculation();
                    }
                    break;
                }
            }
        }
    }
}
