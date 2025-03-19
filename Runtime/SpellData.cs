using System;

/// <summary>
/// Represents a spell, including its form, controller type, power, and modifiers.
/// </summary>
[Serializable]
public class SpellData
{
    public readonly SpellForm Form;
    public readonly Type Controller;
    public float Power { get; private set; }
    public float FlightSpeed { get; private set; } = 10f;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpellData"/> class with the specified form, controller, and power.
    /// </summary>
    /// <param name="form">The form of the spell (e.g., Self, Projectile, MagicSphere).</param>
    /// <param name="controller">The type of the effect controller associated with the spell.</param>
    /// <param name="power">The initial power level of the spell.</param>
    public SpellData(SpellForm form, Type controller, float power)
    {
        Controller = controller;
        Power = power;
        Form = form;
    }

    /// <summary>
    /// Registers an array of modifiers to the spell.
    /// </summary>
    /// <param name="modifiersNames">The names of the modifiers to register.</param>
    /// <param name="config">The configuration of the modifiers.</param>
    /// <remarks>
    /// Currently supported modifiers are "Amplify" and "Accelerate". Each modifier
    /// has a corresponding effect on the spell's power and flight speed, respectively.
    /// </remarks>
    public void RegisterModifiers(string[] modifiersNames, ModifierConfig config)
    {
        foreach (var modifier in modifiersNames)
        {
            switch (modifier)
            {
                case "Amplify":
                    Power *= config.GetFactor("Amplify");
                    break;

                case "Accelerate":
                    FlightSpeed *= config.GetFactor("Accelerate");
                    break;
            }
        }
    }
}
