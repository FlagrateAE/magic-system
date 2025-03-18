using UnityEngine;
using System;

[RequireComponent(typeof(PlayerSpellCast))]
public class PlayerSpellBook : MonoBehaviour
{
    [SerializeField]
    private EffectConfig _effectConfig;
    [SerializeField]
    private ModifierConfig _modifierConfig;

    private PlayerSpellCast _spellCast;

    private void Start()
    {
        _spellCast = GetComponent<PlayerSpellCast>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Debug.Log("Creating Launch with no mods");
            _spellCast.CurrentSpell = CreateSpell(SpellForm.Projectile, "Launch");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Debug.Log("Creating Launch with 1 Amplify");
            _spellCast.CurrentSpell = CreateSpell(SpellForm.Projectile, "Launch", new string[] { "Amplify" });
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Debug.Log("Creating Launch with 1 Accelerate");
            _spellCast.CurrentSpell = CreateSpell(SpellForm.Projectile, "Launch", new string[] { "Accelerate" });
        }
    }

    private SpellData CreateSpell(SpellForm form, string effectName, string[] modifiersNames = null)
    {
        Type controller = Type.GetType($"{effectName}Controller");
        SpellData result = new(form, controller, _effectConfig.GetPower(effectName));

        if (modifiersNames != null)
            result.RegisterModifiers(modifiersNames, _modifierConfig);

        return result;
    }
}
