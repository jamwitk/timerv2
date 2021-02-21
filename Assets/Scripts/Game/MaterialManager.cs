using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Clock;

namespace Game
{
    public class MaterialManager : MonoBehaviour
    {
        public Player.Player player;

        private RotateClock _rotateClock;

        // public ChangeMaterial[] planes;
        public List<ChangeMaterial> planes;
        [HideInInspector] public int random;

        private void Awake()
        {
            // foreach (var plane in GameObject.FindGameObjectsWithTag("12Planes"))
            // {
            //     planes.Add(plane.GetComponent<ChangeMaterial>());
            // }
        }

        private void Start()
        {
            SettingDefaultMaterials();
            SetNewTarget();
        }

        private int RandomMaterialIndex()
        {
            return Random.Range(0, planes[0].materials.Length);
        }

        public void RandomizePlanes()
        {
            random = RandomMaterialIndex();
            for (var i = 0; i < 12; i++)
            {
                planes[i].RandomMaterial(random);
            }
        }

        private static int RandomCustomIndex()
        {
            return Random.Range(0, 12);
        }

        public void SettingDefaultMaterials()
        {
            for (var i = 0; i < planes.Count; i++)
            {
                var plane = planes[i];
                plane.GetDefaultMaterial();
            }
        }

        public void SetNewTarget()
        {
            if (!player.isJumpedToPlane) return;
            random = RandomCustomIndex();
            planes[random].ChangeToCustom();
            player.isJumpedToPlane = false;
        }
    }
}