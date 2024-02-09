using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public TMP_Text ro1;
    public Image img;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plate")
        {
            ro1.text = "100g";
            img.color = Color.black;
            StartCoroutine(wait());
        }
    }


    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        ro1.text = "0.0g";

    }
}