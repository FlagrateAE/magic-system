using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpellCast : MonoBehaviour
{
    [SerializeField]
    private Transform _spellSpawner;
    private readonly ColorGenerator _colors = new();

    [SerializeField]
    private GameObject _spellPrefab;
    private InputAction _castInput;
    [SerializeField]
    private Material _planeMaterial;
    public SpellData CurrentSpell;

    private void Start()
    {
        _castInput = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        if (_castInput.WasPressedThisFrame())
        {
            Cast(CurrentSpell);
        }
    }

    /// <summary>
    /// Casts the given <see cref="SpellData"/> based on its <see cref="SpellForm"/>.
    /// </summary>
    /// <param name="spellData">The spell data to cast.</param>
    /// <remarks>
    /// Currently only supports <see cref="SpellForm.Projectile"/>.
    /// </remarks>
    private void Cast(SpellData spellData)
    {
        switch (spellData.Form)
        {
            case SpellForm.Projectile:
                GameObject spellInstance = Instantiate(_spellPrefab, _spellSpawner.position, _spellSpawner.rotation);

                SpellProjectile spellComponent = spellInstance.GetComponent<SpellProjectile>();
                spellComponent.LoadSpellData(spellData);

                Color color = _colors.GetNextColor();
                Material spellMaterial = spellInstance.GetComponent<MeshRenderer>().material;
                spellMaterial.SetColor("_EmissionColor", color * 1f);

                break;
        }
    }
}

/// <summary>
/// Generates a sequence of colors for spell casting.
/// </summary>
/// <remarks>
/// This class implements <see cref="IEnumerator{Color}"/> and can be used in a <c>foreach</c> loop.
/// </remarks>
public class ColorGenerator : IEnumerator<Color>
{
    private readonly Color[] _colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta };
    private int _position = -1;

    Color IEnumerator<Color>.Current => _colors[_position];
    object IEnumerator.Current => _colors[_position];

    public bool MoveNext() => ++_position < _colors.Length;
    public void Reset() => _position = -1;
    public void Dispose() { }

    public Color GetNextColor()
    {
        _position = (_position + 1) % _colors.Length;
        return _colors[_position];
    }

}
