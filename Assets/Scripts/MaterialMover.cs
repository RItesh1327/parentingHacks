using UnityEngine;
using System.Collections;

public class MaterialMover : MonoBehaviour
{
	public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public string textureName = "_MainTex";
    Renderer m_Renderer;
    Vector2 uvOffset = Vector2.zero;

    private Color TintColor = Color.white;

    public float alphaRate;
    void Start()
    {
        //Fetch the Renderer from the GameObject
        m_Renderer = GetComponent<Renderer>();
    }
    void LateUpdate()
	{
		uvOffset += ( uvAnimationRate * Time.deltaTime );
		if(m_Renderer.enabled )
		{
            m_Renderer.materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );
		}
        //changeAlpha();

    }

    public void changeAlpha()
    {
        TintColor.a = alphaRate;
        m_Renderer.materials[0].color = new Color(1,1,1,alphaRate);
    }
}