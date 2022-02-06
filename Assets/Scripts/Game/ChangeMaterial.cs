using UnityEngine;
public class ChangeMaterial : MonoBehaviour
{
    //Materials
    public Material[] materials;
    public Material customMaterial;
    private Material _defaultMaterial;
    //Main mesh
    private MeshRenderer _mesh;
    private int countNumber;
    private void Start()
    {
         
         //Set Mesh Renderer to _mesh as component
        _mesh = GetComponent<MeshRenderer>();
     
    }
    

    public void GetDefaultMaterial()
    {
        if(_mesh.material == customMaterial) return;
        _defaultMaterial = _mesh.material;
    }
    public void RandomMaterial(int random)
    {
        _mesh.material = materials[random];
    }
    public void ChangeToCustom()
    {
        //Setting custom material to plane
        _mesh.material = customMaterial;
        print(_mesh.name + "  and  " + customMaterial.name);

    }
    
    public void SetToDefault()
    {
        //Setting back default material 
        _mesh.material = _defaultMaterial;
    }
    

}
