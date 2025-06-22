using UnityEngine;

namespace Main_Scene.Character
{
    public class PlayerMaterialController : MonoBehaviour
    {
        
        private void Start()
        {
            transform.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor",GetSelectedColor());
        }

        private static Color GetSelectedColor()
        {
            var storedColorAsString = "#" + PlayerPrefs.GetString("selectedColor","ffd700");
            ColorUtility.TryParseHtmlString(storedColorAsString, out var result);
            return result;
        }
    }

}