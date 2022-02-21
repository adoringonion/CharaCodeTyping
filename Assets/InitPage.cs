using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;

public class InitPage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var container = gameObject.GetComponent<PageContainer>();
        container.Push("TitleUI", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
