using UnityEngine;

[CreateAssetMenu]
public class ModifierConfig : BaseConfig
{
    [Header("Amplify")]
    public float AmplifyFactor = 1.5f;

    [Header("Accelerate")]
    public float AccelerateFactor = 1.5f;

    public float GetFactor(string modifierName) => GetValue<float>(modifierName);
}