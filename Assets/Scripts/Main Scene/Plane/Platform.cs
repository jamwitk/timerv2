using System;
using UnityEngine;

namespace Main_Scene.Plane
{
    public abstract class Platform : MonoBehaviour
    {

        protected string PlatformName { get;  set; }

        public Color PlatformColor { get; set; }
        
    }
}
