using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstantScript : MonoBehaviour
{
    public static ConstantScript Instance;

    public Color teamColor;

    private void Awake()
    {
        if (Instance != null)        //singleton
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
}