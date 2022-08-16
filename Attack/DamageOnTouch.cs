using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D)), HideMonoScript]
public class DamageOnTouch : MonoBehaviour
{
    public Attack damage;

    [Title("Settings")]
    [SerializeField]
    private bool autoDestroyOnContact;

    [SerializeField]
    private UnityEvent onDamaged;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void Awake()
    {
        damage.Init();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Health>() != null)
        {
            Health health = other.GetComponent<Health>();

            if (!other.GetComponent<Tags>().Compare(damage.tagsToDamage))
                return;

            if (health.TryToDamage(damage))
                onDamaged.Invoke();

            if (autoDestroyOnContact)
                PoolManager.ReleaseObject(gameObject);
        }
    }
}