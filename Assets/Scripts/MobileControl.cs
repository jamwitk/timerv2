using UnityEngine;

public class MobileControl : MonoBehaviour
{
    public Player MobilePlayer;
    public Joystick joystick;
    
   
    
    void Update()
    {
        joystickControl();
    }
    public void joystickControl()
    {
        transform.Translate(joystick.Horizontal * MobilePlayer.moveSpeed * Time.deltaTime * MobilePlayer.moveSpeed, 0f, joystick.Vertical * MobilePlayer.moveSpeed * Time.deltaTime * MobilePlayer.moveSpeed);
    }
    public void SpaceButtonOnPointerDown()
    {
        MobilePlayer.moveSpeed = 0;
        MobilePlayer.isCrunched = true;
    }
    public void SpaceButtonOnPointerUp()
    {
        MobilePlayer.moveSpeed = MobilePlayer._moveSpeed;
        MobilePlayer.isCrunched = false;
    }
}
