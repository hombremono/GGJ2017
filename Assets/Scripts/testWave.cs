using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testWave : MonoBehaviour
{

    private Transform target;
    private Transform CurrentPos;
    public float speed;
    public float WaveStrength=10;
    public char[] Sequence;
    public int ElementIndex;

    public float movementTime = 2;
    private float lerpTime = 0.05f;

    Image[] images;
    public Sprite imageX;
    public Sprite imageY;
    public Sprite imageA;
    public Sprite imageB;


    // Use this for initialization
    void Start ()
    {
        
        target = SystemSingleton.Instance.centerPoint;
        Vector3 p1 = gameObject.transform.position;
        Vector3 p2 = target.transform.position;
        float angle = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 180 / Mathf.PI;
        gameObject.transform.Rotate(new Vector3(0,0,angle));
        StartCoroutine("MoveTo", p2);

    }

    IEnumerator MoveTo(Vector3 destination)
    {
        float timeEllapsed = 0;
        Vector3 origin = transform.position;

        while (timeEllapsed < movementTime)
        {
            transform.position = Vector3.Lerp(origin, destination, timeEllapsed / movementTime);
            timeEllapsed += lerpTime;
            yield return new WaitForSeconds(lerpTime);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        SystemSingleton.Instance.WaveHit(WaveStrength);
        WavesSingleton.Instance.RemoveWave(gameObject);
        

    }
    public void setSequenceText()
    {

        string txtSequence = new string(Sequence);
        
       // gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = txtSequence;
    }
    public void setSequenceImage()
    {
        images = gameObject.GetComponentInChildren<Canvas>().GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++)
        {
            Sprite newImage = null;
            switch (Sequence[i])
            {
                case 'A':
                    newImage = imageA;
                    break;
                case 'B':
                    newImage = imageB;
                    break;
                case 'X':
                    newImage = imageX;
                    break;
                case 'Y':
                    newImage = imageY;
                    break;
                default:
                    break;
            }
            images[i].sprite = newImage;
        }
    }
}
