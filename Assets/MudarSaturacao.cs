using UnityEngine;

public class MudarSaturacao : MonoBehaviour
{
    public float novaSaturacao = 1.5f; // Valor desejado para a saturação
    public Material[] todosMateriais;

    void Start()
    {
        MudarSaturacaoMateriais();
    }

    void MudarSaturacaoMateriais()
    {
         todosMateriais = Resources.FindObjectsOfTypeAll<Material>();

        foreach (Material material in todosMateriais)
        {
            if (material.HasProperty("_Color"))
            {
                Color corAtual = material.color;
                Color novaCor = ColorHSV.AjustarSaturacao(corAtual, novaSaturacao);
                material.color = novaCor;
            }
        }
    }
}

public static class ColorHSV
{
    public static Color AjustarSaturacao(Color cor, float novaSaturacao)
    {
        Color.RGBToHSV(cor, out float h, out float s, out float v);
        return Color.HSVToRGB(h, Mathf.Clamp01(s * novaSaturacao), v);
    }
}