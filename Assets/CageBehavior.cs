using UnityEngine;

public class CageBehavior : MonoBehaviour {

    /* Fields */

    public int m_CageStage;
    [Space(20)]
    public Sprite m_CageBroken;

    private SpriteRenderer m_CageRenderer;


    /* Methods */

    void Start ()
    {
        // Init fields
        m_CageStage = 2;
        // Search for spriteRenderer of the cage sprite
        SpriteRenderer[] renderers = gameObject.GetComponents<SpriteRenderer>();
        foreach(SpriteRenderer renderer in renderers)
        {
            if(renderer.gameObject.name.Equals("CageSprite"))
            {
                m_CageRenderer = renderer;
            }
        }
	}
	

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if(_collision.gameObject.CompareTag("Player"))
        {
            if(m_CageStage > 0)
            {
                m_CageStage--;
                ChangeCageStage(m_CageStage);
            }
        }
    }

    /// <summary>
    /// This method chages the stage of the cage
    /// </summary>
    /// <param name="_newStage">The next stage for the cage</param>
    public void ChangeCageStage(int _newStage)
    {
        switch (_newStage)
        {
            case 0:
                // Make the sprite for the cage disapear
                m_CageRenderer.enabled = false;
                break;

            case 1:
                // Change the sprite to broken
                m_CageRenderer.sprite = m_CageBroken;
                break;

            default:
                Debug.Log("Invalid cage stage");
                break;
        }
    }
}
