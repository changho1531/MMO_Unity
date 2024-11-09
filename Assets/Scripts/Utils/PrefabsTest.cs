using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsTest : MonoBehaviour
{

    GameObject tank;

    void Start()
    {
        tank = Managers.Resource.Instantiate("tank");

        Managers.Resource.Destroy(tank);
    }
}
