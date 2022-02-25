using System;
using Audio;
using Game;
using Main_Scene.Score;
using UnityEngine;

namespace Main_Scene.Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        private MaterialManager _materialManager;
        private ScoreManager _scoreManager;
        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _materialManager = FindObjectOfType<MaterialManager>();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!GameManager.Instance.isGame) return;
            
            switch (hit.gameObject.tag)
            {
                case "12Planes":
                    if (hit.gameObject.name == "12Plane"+_materialManager.random)
                    {
                        GameManager.Instance.PlayParticle();
                        GameManager.Instance.particle.transform.position = transform.position;
                        StartCoroutine(GameManager.Instance.StopParticle());
                        AudioManager.Instance.Play("JumpPlane");
                        _materialManager.planes[_materialManager.random].GetComponent<ChangeMaterial>().SetMaterialToDefault();
                        _materialManager.SetNewTarget();
                        _scoreManager.ScoreCombo++;
                        _scoreManager.ScoreCalculation();
                    }
                    break;
                case "Clock":
                {
                    GameManager.Instance.FinishGame();
                    break;
                }
            }
        }
    }
}
