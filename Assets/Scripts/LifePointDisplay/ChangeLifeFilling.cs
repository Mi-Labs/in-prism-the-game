using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLifeFilling : MonoBehaviour {

    private GameObject m_player;
    private Image m_LifeImage;

	// Use this for initialization
	void Start ()
    {
        m_LifeImage = gameObject.GetComponentInChildren<Image>();
        m_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_LifeImage.gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y, m_player.transform.rotation.z);
	}

    public void SetNewLifePoint(int _newLifePoint)
    {
        if(_newLifePoint > 0 && _newLifePoint <= 100)
        {
            float actualLifePoints = (float)_newLifePoint / 100.0f;
            m_LifeImage.fillAmount = actualLifePoints;
        }
    }
}
