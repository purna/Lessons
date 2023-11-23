using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToUrl : MonoBehaviour
{

    public string urllink;
 

    public void goToUrlLink(string urllink)
    {
        Application.OpenURL(urllink);
    }
}
