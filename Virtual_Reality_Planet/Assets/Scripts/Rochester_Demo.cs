using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rochester_Demo : MonoBehaviour
{

    public TextAsset star_Data;
    public ParticleSystem particleSys;

    private DateTime dt = DateTime.UtcNow;

    private float ROCHESTER_LAT = 43.128002f;
    private float ROCHESTER_LONG = -77.665474f;

    // Start is called before the first frame update
    void Start()
    {
        StarContainer s = StarPlotter.Create_Star_Cluster(star_Data);
        StarPlotter.Plot_Star_Cluster(s, particleSys, ROCHESTER_LAT, ROCHESTER_LONG, dt, true);
    }

}
