using System;
using Audio;
using Game;
using Score;
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
            if (!GameManager.instance.isGame) return;
            
            switch (hit.gameObject.tag)
            {
                case "12Planes":
                    if (hit.gameObject.name == "12Plane"+_materialManager.random)
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
                case "Clock":
                {
                    GameManager.instance.FinishGame();
                    break;
                }
            }
        }
    }
}
