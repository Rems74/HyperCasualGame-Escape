using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject[] Key;
    MeshRenderer DoorOpen;
    [SerializeField] Material MaterialDoor;

    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        DoorOpen = GetComponent<MeshRenderer>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isOpen == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Key = GameObject.FindGameObjectsWithTag("Key");
      
        print(DoorOpen.material.color);
        if (Key.Length == 0 && isOpen == false)
        {
            isOpen = true;
            DoorOpen.material.SetColor("_Color", new Color(0, 255, 0));
        }
    }
}
