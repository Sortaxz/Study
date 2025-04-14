using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructure<T>
{
    List<T> data;

    public List<T> A(params T[] a)
    {
        data = new List<T>(a);
        foreach (var item in data)
        {
            Debug.Log(item);
        }
        return data;
    }

}

