using Game;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Properties")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Joystick joystick;
    
    private CharacterController _characterController;
    private float _ySpeed;
    private bool _isCrunched;
    private float _cachedMoveSpeed;
    private Vector3 _playerMovementOffset;
    
    #region Events
    private void Start()
    {
        _cachedMoveSpeed = moveSpeed;
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _ySpeed += Physics.gravity.y * Time.deltaTime;
        if (!GameManager.instance.isGame) return;
        
        //Move();
        
        if (!_isCrunched && _characterController.isGrounded)
        {
            Jump();
        }

        _playerMovementOffset = new Vector3(joystick.Horizontal * moveSpeed, _ySpeed, joystick.Vertical * moveSpeed);
        _characterController.Move(_playerMovementOffset * Time.deltaTime);

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
    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    
    #region Mechanics

    private void Jump()
    {
        _ySpeed = -0.50f;
        _ySpeed = jumpForce;
    }

    #endregion
}
