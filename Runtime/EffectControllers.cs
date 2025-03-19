using UnityEngine;

public abstract class EffectController : MonoBehaviour
{
    protected float _power;
    protected SpellForm _form;

    /// <summary>
    /// Sets the EffectController up to apply the effect represented by the
    /// given SpellData.
    /// </summary>
    /// <param name="spell">The SpellData representing the effect to apply.</param>
    public void Initialize(SpellData spell)
    {
        _form = spell.Form;
        _power = spell.Power;

        ApplyEffect();
    }

    public abstract void ApplyEffect();
}

public class LaunchController : EffectController
{
    /// <summary>
    /// Applies the effect by adding an upward force to the Rigidbody. The magnitude
    /// of the force is determined by the power of the spell.
    /// </summary>
    public override void ApplyEffect()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * _power, ForceMode.Impulse);
    }
}