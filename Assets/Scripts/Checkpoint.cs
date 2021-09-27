using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Material colorMaterial;

    [SerializeField] private GameObject pointBar;
    [SerializeField] private ParticleSystem[] pointParticles;

    // Start
    void Start()
    {
        FillPool();
        SelectColor();
    }

    // Fills pool
    private void FillPool()
    {
        // Temp mats pool
        List<Material> tempMaterials = new List<Material>();
        foreach (Material material in ColorsManager.i.materialsPool)
        {
            tempMaterials.Add(material);
        }

        // Clear current pool
        ColorsManager.i.currentPool.Clear();

        // Get only two colors
        for (int i = 0; i < 2; i++)
        {
            Material randomMaterial = tempMaterials[Random.Range(0, tempMaterials.Count)];

            // Add and remove material
            tempMaterials.Remove(randomMaterial);
            ColorsManager.i.currentPool.Add(randomMaterial);
        }
    }

    // Selects color
    private void SelectColor()
    {
        colorMaterial = ColorsManager.i.currentPool[Random.Range(0, ColorsManager.i.currentPool.Count)];

        // Bar Material
        pointBar.GetComponent<MeshRenderer>().material = colorMaterial;

        // Particle Colors
        foreach (ParticleSystem pointParticle in pointParticles)
        {
            ParticleSystem.MainModule particleSettings = pointParticle.main;
                particleSettings.startColor = colorMaterial.color;
                particleSettings.prewarm = true;
        }
    }

    // OnTriggerEnter
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Snake")
        {
            MeshRenderer snakeMesh = collider.gameObject.GetComponent<MeshRenderer>();
                snakeMesh.material = colorMaterial;
        }
    }
}
