using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConstruct : MonoBehaviour
{
    AnotherClass myClassVar;
    private void Start()
    {
        myClassVar = new AnotherClass(300);

        myClassVar.x = 7;
    }
}

public class AnotherClass
{
    public int x = 0;
    public AnotherClass()
    {
        x = 4;
        Debug.Log("Hallo");
    }

    public AnotherClass(int pog)
    {
        x = 3;
    }
}