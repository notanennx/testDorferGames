using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour
{
    public static ColorsManager i;
    [HideInInspector] public Material[] materialsPool;
    public List<Material> currentPool = new List<Material>();

    // Awake
    private void Awake()
    {
        i = this;

        materialsPool = Resources.LoadAll<Material>("Materials/Colors");
    }
}
