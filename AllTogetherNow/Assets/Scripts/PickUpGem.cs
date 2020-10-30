using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpGem : MonoBehaviour
{
    public bool hasGem = false;
    public GameObject gem_notif;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FZGEM") == 1)
        {
           hasGem = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Weapon") && !hasGem)
        {
            hasGem = true;
            gameObject.GetComponent<Animator>().SetBool("Gem Taken", true);
            StartCoroutine("GemNotif");
        }
    }

    IEnumerator GemNotif()
    {
        gem_notif.SetActive(true);
        yield return new WaitForSeconds(2);
        gem_notif.SetActive(false);
    }

}
