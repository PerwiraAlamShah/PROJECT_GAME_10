using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointOrange;

    public void Setup(int orange)
    {
        gameObject.SetActive(true);
        pointOrange.text = "" + orange;
    }
}
