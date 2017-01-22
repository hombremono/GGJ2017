using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TikisManager : MonoBehaviour {

    Image[] images;
    public Sprite Mascara;
    public Sprite Cara;
    public UnityEngine.Color X_color;
    public Color Y_color;
    public Color A_color;
    public Color B_color;
    // Use this for initialization
    void Start () {
        images = gameObject.GetComponentInChildren<Canvas>().GetComponentsInChildren<Image>();
        print("tikis " + images.Length);
        ClearTikis();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void ClearTikis()
    {
        foreach (var imagen in images)
        {
            imagen.enabled=false;
        }
    }
    public void DrawTikis(List<char> Stack)
    {
        int count = 5;
        foreach (var tiki in Stack)
        {
            switch (tiki)
            {
                case 'A':
                    print("A");
                    images[count].color = A_color;
                    images[count].sprite = Cara;
                    images[count].enabled = true;
                    count--;
                    break;
                case 'B':
                    print("B");
                    images[count].sprite = Cara;
                    images[count].color = B_color;
                    images[count].enabled = true;
                    count--;
                    break;
                case 'X':
                    print("X");
                    images[count].sprite = Cara;
                    images[count].color = X_color;
                    images[count].enabled = true;
                    count--;
                    break;
                case 'Y':
                    print("Y");
                    images[count].sprite = Cara;
                    images[count].color = Y_color;
                    images[count].enabled = true;
                    count--;
                    break;
                default:
                    break;
            }
            images[count].sprite = Mascara;
            images[count].enabled = true;
            count--;

           
            
            
        }
        for (int i = count; i >=0; i--)
        {
            images[count].enabled = false;
        }
    }
}
