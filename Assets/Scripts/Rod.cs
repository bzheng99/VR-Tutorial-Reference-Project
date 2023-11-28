using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public Transform flameSpawn;
    private Element chosenElement;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("element"))
        {
            chosenElement = other.gameObject.GetComponent<Element>();
        }
        else if (other.gameObject.CompareTag("flame"))
        {
            if (chosenElement != null)
            {
                RemoveFlame();
                CreateFlame();
                chosenElement = null;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("flame"))
        {
            StopFlame();
        }
    }
    
    private void RemoveFlame()
    {
        foreach (Transform child in flameSpawn)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void CreateFlame()
    {
        GameObject flame = Instantiate(chosenElement.FlamePrefab, flameSpawn);
        flame.transform.localPosition = Vector3.zero;
        flame.transform.localRotation = Quaternion.identity;
    }

    private void StopFlame()
    {
        foreach (Transform child in flameSpawn)
        {
            ParticleSystem particleSystem = child.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Stop();
            }
        }
    }
}