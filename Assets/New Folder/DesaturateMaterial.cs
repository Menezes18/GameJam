using UnityEngine;

public class DesaturateMaterial : MonoBehaviour
{
    public Material targetMaterial;

    void Start()
    {
        if (targetMaterial == null)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                targetMaterial = renderer.material;
            }
            else
            {
                Debug.LogError("Target material not assigned and no renderer found on the GameObject.");
                return;
            }
        }

        Desaturate();
    }

    void Desaturate()
    {
        if (targetMaterial != null)
        {
            Shader desaturateShader = Shader.Find("Custom/DesaturateShader"); // Use o nome do shader que você criar
            if (desaturateShader != null)
            {
                targetMaterial.shader = desaturateShader;
            }
            else
            {
                Debug.LogError("Desaturate shader not found. Create a shader with the name 'Custom/DesaturateShader'.");
            }
        }
    }
}