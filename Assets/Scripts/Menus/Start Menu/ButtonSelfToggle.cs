using UnityEngine;
using UnityEngine.UI;

public class ButtonSelfToggle : MonoBehaviour {

    public int m_OwnLevelNumber;

    public Sprite m_ReloadSprite;

    private int m_HighestNumber;

	// Use this for initialization
	void Start ()
    {
        m_HighestNumber = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>().GetHighestLevelNumber();

        bool admin_mode = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>().m_AdminMode; 

        if (m_OwnLevelNumber > m_HighestNumber+1 && !admin_mode)
        {
            gameObject.SetActive(false);
        }

        if(m_OwnLevelNumber <= m_HighestNumber)
        {
            gameObject.GetComponent<Image>().sprite = m_ReloadSprite;
        }

	}
	
}
