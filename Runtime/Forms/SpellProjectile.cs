using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class SpellProjectile : MonoBehaviour
{
    public SpellData SpellData { get; private set; }

    private float _speed;
    private string _effectName;
    private Rigidbody _rb;


    /// <summary>
    /// Sets the Rigidbody's velocity to move the projectile.
    /// </summary>
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.linearVelocity = transform.forward * _speed;
    }

    /// <summary>
    /// When a SpellProjectile hits a SpellInteractable, apply the associated
    /// SpellData to that SpellInteractable.
    /// </summary>
    private void OnTriggerEnter(Collider target)
    {
        if (
            target.gameObject.TryGetComponent(out SpellInteractable interactable)
            && interactable.IsCompatibleWith(_effectName)
        )
        {
            interactable.ApplySpell(SpellData);
        }
    }

    /// <summary>
    /// Sets up the SpellProjectile to represent the given SpellData.
    /// </summary>
    /// <param name="data">The SpellData to set up the projectile to represent.</param>
    public void LoadSpellData(SpellData data)
    {
        SpellData = data;
        _effectName = data.Controller.Name.Split("Controller")[0];
        _speed = data.FlightSpeed;
    }
}
