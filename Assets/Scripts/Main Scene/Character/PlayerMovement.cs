using Game;
using Scriptable_Objects;
using UnityEngine;

namespace Main_Scene.Character
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Player Properties")]
        [SerializeField] private Joystick joystick;
        [SerializeField] private PlayerProperties playerProperties;
        private CharacterController _characterController;
        private float _ySpeed;
        private bool _isCrunched;
        private float _cachedMoveSpeed;
        private Vector3 _playerMovementOffset;
        private Vector3 _defaultPosition;
        #region Events
        private void Start()
        {
            _cachedMoveSpeed = playerProperties.movementSpeed;
            _defaultPosition = transform.localPosition;
            _characterController = GetComponent<CharacterController>();
            
        }
        private void Update()
        {
            _ySpeed += Physics.gravity.y * Time.deltaTime;
            if (!GameManager.Instance.isGame) return;
            
            
            if (!_isCrunched && _characterController.isGrounded)
            {
                Jump();
            }

            _playerMovementOffset = new Vector3(joystick.Horizontal * playerProperties.movementSpeed, _ySpeed, joystick.Vertical * playerProperties.movementSpeed);
            _characterController.Move(_playerMovementOffset * Time.deltaTime);

            if(transform.position.y <= -1)
            {
                GameManager.Instance.FinishGame();
            }
        }
        public void OnSpaceButtonDown()
        {
            SetMoveSpeed(0);
            _isCrunched = true;
        }

        public void OnSpaceButtonUp()
        {
            SetMoveSpeed(_cachedMoveSpeed);
            _isCrunched = false;
        }

        #endregion
        private void SetMoveSpeed(float speed)
        {
            playerProperties.movementSpeed = speed;
        }

        public void SetPlayerProperties(PlayerProperties property)
        {
            playerProperties = property;
        }
        #region Mechanics

        private void Jump()
        {
            _ySpeed = -0.50f;
            _ySpeed = playerProperties.jumpForce;
        }

        public void ResetPlayerPhysic()
        {
            transform.localPosition = _defaultPosition;
        }
        #endregion
    }

}