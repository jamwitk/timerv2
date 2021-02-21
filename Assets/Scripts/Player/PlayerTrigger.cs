using System;
using Game;
using Score;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    
    private Player.Player _player;
    [SerializeField]private MaterialManager materialManager;
    [SerializeField]private ScoreManager scoreManager;
    private void Start()
    {
        _player = GetComponent<Player.Player>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _player.isGrounded = true;
        switch (other.gameObject.tag)
        {
            case "12Planes":
            {
                _player.isJumpedToPlane = true;

                if (other.gameObject.name == "12Plane"+materialManager.random)
                {
                    GameManager.instance.PlayParticle();

                    GameManager.instance.particle.transform.position = transform.position;

                    StartCoroutine(GameManager.instance.StopParticle());
                    
                    AudioManager.Instance.Play("JumpPlane");
                    
                    materialManager.planes[materialManager.random].GetComponent<ChangeMaterial>().SetToDefault();
                    
                    materialManager.SetNewTarget();

                    scoreManager.ScoreCombo++;
                    
                    scoreManager.ScoreCalculation();

                }
                break;
            }
        }
    }
}
