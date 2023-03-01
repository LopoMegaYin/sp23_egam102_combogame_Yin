using UnityEngine;
using UnityEngine.SceneManagement; //You need to add this line manually. Without it SceneManager scripts won't work.
using System.Collections;

public class NewKillWall : MonoBehaviour
{
public GameObject RKW1;
public GameObject RKW2;
public GameObject BKW1;
public GameObject BKW2;
public int controlselect;
    
    private void Awake()
    {
        controlselect = UnityEngine.Random.Range(0, 2);
    }
    
    void Update()
	{
	if (controlselect == 0)
        {
            RKW1.SetActive(true);
            BKW1.SetActive(true);
            Destroy(this.gameObject);
        }

        if (controlselect == 1)
        {
            RKW2.SetActive(true);
            BKW2.SetActive(true);
            Destroy(this.gameObject);
        }

    }
}