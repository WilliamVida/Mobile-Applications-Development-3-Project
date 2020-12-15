using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShip : MonoBehaviour
{

    [SerializeField] GameObject[] Ships;
    int currentShip = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerShip"))
        {
            currentShip = PlayerPrefs.GetInt("PlayerShip");
        }
        this.transform.LookAt(Ships[currentShip].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentShip++;
            if (currentShip > Ships.Length - 1)
            {
                currentShip = 0;
            }
            PlayerPrefs.SetInt("PlayerShip", currentShip);
        }
        Quaternion lookDir = Quaternion.LookRotation(Ships[currentShip].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookDir, Time.deltaTime * 5);
    }

}
