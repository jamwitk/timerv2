using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Player Properties")]
    public class PlayerProperties : ScriptableObject
    {
        public float movementSpeed;
        public float jumpForce;
        public float duration;
    }
}