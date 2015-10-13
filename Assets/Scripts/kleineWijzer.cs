using UnityEngine;
using System.Collections;

public class kleineWijzer : MonoBehaviour{

    // Use this for initialization
    public void rotate() {
        Vector3 rotation;
        rotation = new Vector3(90, 0, 0);
        transform.Rotate(rotation);
    }

}
