using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDestroy : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] bool die;

    void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(time);
        if (die)
            Destroy(gameObject);
        gameObject.SetActive(false);
    }
}