using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemCollect : MonoBehaviour
{
    public GameObject hitEffect;
    private int orange = 0;
    public TextMeshProUGUI textScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Orange"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(other.gameObject);
            orange += 1;
            Debug.Log("Orange : " + orange);
            textScore.text = "" + orange;
        }
    }
}
