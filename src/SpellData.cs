using System;

[Serializable]
public class SpellData
{
    public readonly SpellForm Form;
    public readonly Type Controller;
    public float Power { get; private set; }
    public float FlightSpeed { get; private set; } = 10f;

    public SpellData(SpellForm form, Type controller, float power)
    {
        Controller = controller;
        Power = power;
        Form = form;
    }

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
