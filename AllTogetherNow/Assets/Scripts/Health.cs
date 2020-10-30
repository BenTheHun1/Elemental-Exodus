using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    private int hp;
    private UnityEngine.UI.Image[] hearts;
    public Sprite full;
    public Sprite half;
    public Sprite empty;


    // Start is called before the first frame update
    void Start()
    {
        hp = 6;
        hearts = new UnityEngine.UI.Image[3];
        hearts[0] = GameObject.Find("Heart1").GetComponent<UnityEngine.UI.Image>();
        hearts[1] = GameObject.Find("Heart2").GetComponent<UnityEngine.UI.Image>();
        hearts[2] = GameObject.Find("Heart3").GetComponent<UnityEngine.UI.Image>();
        UpdateHearts();
    }

    // Update is called once per frame
    void UpdateHearts()
    {
        if (hp == 6)
        {
            foreach (UnityEngine.UI.Image heart in hearts)
            {
                heart.sprite = full;
            }
        }
        else if (hp == 5)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = full;
            hearts[2].sprite = half;
        }
        else if (hp == 4)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = full;
            hearts[2].sprite = empty;
        }
        else if (hp == 3)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = half;
            hearts[2].sprite = empty;
        }
        else if (hp == 2)
        {
            hearts[0].sprite = full;
            hearts[1].sprite = empty;
            hearts[2].sprite = empty;
        }
        else if (hp == 1)
        {
            hearts[0].sprite = half;
            hearts[1].sprite = empty;
            hearts[2].sprite = empty;
        }
        else if (hp <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    
    public void takeDamage(int dmg)
    {
        hp -= dmg;
        UpdateHearts();
    }
}
