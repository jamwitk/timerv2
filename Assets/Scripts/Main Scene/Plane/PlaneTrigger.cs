using Game;
using Score;
using UnityEngine;

namespace Main_Scene.Plane
{
    public class PlaneTrigger : Platform
    {
        private global::Player.Player _player;
        private MaterialManager _materialManager;
        private ScoreManager _scoreManager;
        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _player = FindObjectOfType<global::Player.Player>();
            _materialManager = FindObjectOfType<MaterialManager>();
            PlatformName = GetComponent<Transform>().name;
        }
        
    }
}
