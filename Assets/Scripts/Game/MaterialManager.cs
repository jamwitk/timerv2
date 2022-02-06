using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class MaterialManager : MonoBehaviour
    {
         public Player.Player player;

        // public ChangeMaterial[] planes;
         public List<ChangeMaterial> planes;
         public int random;

         private void Start()
        {
            SettingDefaultMaterials();
            SetNewTarget();
        }

        private int GetRandomMaterialIndex()
        {
            return Random.Range(0, planes[0].materials.Length);
        }

        public void Reset()
        {
            RandomizePlanes(); 
            SettingDefaultMaterials();
            SetNewTarget();
        }
        private void RandomizePlanes()
        {
            random = GetRandomMaterialIndex();
            for (var i = 0; i < 12; i++)
            {
                planes[i].RandomMaterial(random);
            }
        }

        private static int GetRandomCustomIndex()
        {
            return Random.Range(0, 12);
        }

        private void SettingDefaultMaterials()
        {
            foreach (var plane in planes)
            {
                plane.GetDefaultMaterial();
            }
        }

        public void SetNewTarget()
        {
            random = GetRandomCustomIndex();
            planes[random].ChangeToCustom();
        }
    }
}