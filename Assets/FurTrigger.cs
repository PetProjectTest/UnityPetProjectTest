using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurTrigger : MonoBehaviour
{
    List<GameObject> furs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            FurActive();
        }
    }

    public void FurActive() {
        if (furs.Count == 0) {
            for (int i = 0; i < 5; i++) {
                Transform fur = transform.Find("Cat.R_Fur_LOD" + i);
                fur.gameObject.SetActive(false);
                furs.Add(fur.gameObject);
            }
        } else {
            foreach (GameObject fur in furs) {
                if (fur.activeSelf) {
                    fur.SetActive(false);
                } else {
                    fur.SetActive(true);
                }
            }
        }
    }
}
