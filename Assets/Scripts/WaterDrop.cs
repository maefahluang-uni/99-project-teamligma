using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidInteraction : MonoBehaviour
{
    public GameObject WaterleakParticlePrefab;
    public Transform Droppoint;
    public Renderer rend;

    private List<GameObject> instantiatedParticles = new List<GameObject>();

    private void Update()
    {
        CheckRotationAngles();
    }

    private void CheckRotationAngles()
    {
        float angle = transform.rotation.eulerAngles.z;

        if ((angle >= 100f && angle <= 270f) || (angle <= -100f && angle >= -270f))
        {
            // Instantiate the particle effect and store the reference
            GameObject particle = Instantiate(WaterleakParticlePrefab, Droppoint.position, Droppoint.rotation);
            instantiatedParticles.Add(particle);

            // Start a coroutine to wait and then destroy the particle
            StartCoroutine(WaitAndDestroyParticle(particle));
        }
    }

    private IEnumerator WaitAndDestroyParticle(GameObject particle)
    {
        yield return new WaitForSeconds(0.1f); // Adjust the waiting time as needed
        Destroy(particle);
        instantiatedParticles.Remove(particle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Waterdrop(Clone)")
        {
            float currentFill = rend.material.GetFloat("_Fill");
            currentFill += 0.001f;
            rend.material.SetFloat("_Fill", currentFill);
        }
    }
}
