using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class SpellProjectile : MonoBehaviour
{
    public SpellData SpellData { get; private set; }

    private float _speed;
    private string _effectName;
    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.linearVelocity = transform.forward * _speed;
    }

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

    public void LoadSpellData(SpellData data)
    {
        SpellData = data;
        _effectName = data.Controller.Name.Split("Controller")[0];
        _speed = data.FlightSpeed;
    }
}
