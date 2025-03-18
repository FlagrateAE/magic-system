using UnityEngine;
using System.Linq;
using System;

public class SpellInteractable : MonoBehaviour
{
    private readonly string[] _compatibleEffects = { "Launch", "Enlarge" };

    public bool IsCompatibleWith(string effectName) => _compatibleEffects.Contains(effectName);

    public void ApplySpell(SpellData spell)
    {
        var controller = (EffectController)gameObject.AddComponent(spell.Controller);
        controller.Initialize(spell);
    }
}