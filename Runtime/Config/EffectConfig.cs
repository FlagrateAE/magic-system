using UnityEngine;

[CreateAssetMenu]
public class EffectConfig : BaseConfig
{
    [Header("Launch")]
    public Color LaunchColor = Color.white;
    public float LaunchForce = 10f;

    [Header("Enlarge")]
    public Color EnlargeColor = Color.red;
    public float EnlargeFactor = 1.5f;

    public float GetPower(string effectName) => GetValue<float>(effectName);
    
    public Color GetColor(string effectName) => GetValue<Color>(effectName);
}