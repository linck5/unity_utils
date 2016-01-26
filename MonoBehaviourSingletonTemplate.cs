using UnityEngine;
using System.Collections;

public class MonoBehaviourSingletonTemplate : MonoBehaviour {

    private static MonoBehaviourSingletonTemplate instance = null;
    public static MonoBehaviourSingletonTemplate inst {
        get { if (!instance) instance = GameObject.FindObjectOfType<MonoBehaviourSingletonTemplate>(); return instance; }
    }
	
}
