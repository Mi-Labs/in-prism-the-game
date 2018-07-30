using UnityEngine;
using UnityEngine.UI;

public class ChangeLifeFilling : MonoBehaviour {

    public float m_RotationFactor = 2;

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
        Rigidbody2D rb2D = m_player.GetComponent<Rigidbody2D>();

        m_RotationFactor = rb2D.velocity.x > 0 ? +m_RotationFactor : m_RotationFactor;

        Quaternion newRotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y, m_player.transform.rotation.z+ m_RotationFactor);

        //m_LifeImage.GetComponent<RectTransform>().rotation = newRotation;
        gameObject.GetComponent<RectTransform>().rotation = newRotation;
     
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
