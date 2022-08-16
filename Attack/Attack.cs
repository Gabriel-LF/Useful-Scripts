using Sirenix.OdinInspector;
using System;
using UnityEngine;

[Serializable, HideLabel, InlineProperty, Title("Attack")]
public class Attack
{
    public int damage;
    public bool randomizeId;
    [HideIf(nameof(randomizeId))]
    public float id;
    [ListDrawerSettings(Expanded = true)]
    public CustomTag[] tagsToDamage;
    public GameObject damageVFX;

    public void Init()
    {
        if (randomizeId)
            id = UnityEngine.Random.Range(Mathf.NegativeInfinity, Mathf.Infinity);
    }
}