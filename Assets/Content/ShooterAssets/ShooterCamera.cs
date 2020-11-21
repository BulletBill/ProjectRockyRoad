using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCamera : MonoBehaviour
{

    public static ShooterCamera _Camera { get; protected set; }
	// Start is called before the first frame update

	public Rect CameraRect;

    void Awake()
    {
		if (_Camera == null)
		{
			_Camera = this;
			CalculateRect();
		}
		else
		{
			Object.Destroy(this.gameObject);
			return;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public Vector2 CameraSize()
	{
		float CamHeight = GetComponent<Camera>().orthographicSize * 2.0f;
		float CamWidth = CamHeight * GetComponent<Camera>().aspect;

		return new Vector2(CamWidth, CamHeight);
	}

	public Vector2 CameraPosition()
	{
		return new Vector2(transform.position.x, transform.position.y);
	}

	void CalculateRect()
	{
		// Call at start and when camera moves
		CameraRect = new Rect(_Camera.CameraPosition() - (_Camera.CameraSize() / 2.0f), _Camera.CameraSize());
	}

	public static bool RectOnCamera(Rect InRect)
	{
		if (_Camera == null) return false;

		return _Camera.CameraRect.Overlaps(InRect);
	}

	public static bool SpriteOnCamera(SpriteRenderer InSprite)
	{
		if (_Camera == null) return false;

		float SpriteWidth = InSprite.sprite.rect.width / InSprite.sprite.pixelsPerUnit;
		float SpriteHeight = InSprite.sprite.rect.height / InSprite.sprite.pixelsPerUnit;
		Rect SpriteRect = new Rect(InSprite.transform.position.x, InSprite.transform.position.y, SpriteWidth, SpriteHeight);

		return _Camera.CameraRect.Overlaps(SpriteRect);
	}
}
