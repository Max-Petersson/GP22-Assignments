using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingProcessing : ProcessingLite.GP21
{
    public float x;
    float y = 20f;

    void Start()
    {
        Line(0f, 0f, .5f, 1f);
        Line(.5f, 1f, 1f, 0f);
        Line(1f, 0f, 1.5f ,1f);
        Line(1.5f, 1f, 2f, 0f);

        Line(2.5f, 0f, 2.5f, 1f);
        Line(2.5f, 1f, 3f, 1f);
        Line(3f, 1f, 3f, 0.5f);
        Line(3f, 0.5f, 2.5f, 0.5f);

        for (float i = 0; i < 20; i++)
        {
            Line(0f, y, i, 0f);
            y--;
        }
    }
}
