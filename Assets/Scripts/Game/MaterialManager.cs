using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Game
{
    public class MaterialManager : Singleton<MaterialManager>
    {

         public List<ChangeMaterial> planes;
         public int random;

         private void Start()
        {
            SettingDefaultMaterials();
            SetNewTarget();
            GameManager.Instance.OnRestartGame += Reset;
        }

         private void OnDestroy()
         {
             GameManager.Instance.OnRestartGame -= Reset;
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
                planes[i].SetRandomMaterial(random);
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
            planes[random].ChangeMaterialToCustom();
        }
    }
}