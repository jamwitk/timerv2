using UnityEngine;

namespace Game
{
    public class ChangeMaterial : MonoBehaviour
    {
        public Material[] materials;
        public Material customMaterial;

        private Material _defaultMaterial;

        private MeshRenderer _mesh;

        private void Start()
        {
            _mesh = GetComponent<MeshRenderer>();
        }


        public void GetDefaultMaterial()
        {
            if (_mesh.material == customMaterial) return;
            _defaultMaterial = _mesh.material;
        }

        public void SetRandomMaterial(int random)
        {
            _mesh.material = materials[random];
        }

        public void ChangeMaterialToCustom()
        {
            _mesh.material = customMaterial;

        }

        public void SetMaterialToDefault()
        {
            _mesh.material = _defaultMaterial;
        }


    }
}