using UnityEngine;
using System.Collections;

public enum BULocateOrigin
{
	Center,
	BottomLeft,
}

[ExecuteInEditMode()]
[RequireComponent (typeof(BUSprite))]
public class BULocate : MonoBehaviour
{
	public BUSprite Container = null;
	public BULocateOrigin Style = BULocateOrigin.Center;
	public Vector2 RelativePosition = Vector2.one * 0.5f;

	private BUSprite sprite;
	
	void Awake()
	{
		sprite = GetComponent<BUSprite>();
	}

	void Update()
	{
		var parent_pos = (Container == null) ? Vector2.zero : Container.ViewNormalizedPosition;
		var parent_size = (Container == null) ? Vector2.one : Container.ViewNormalizedSize;
		var offset = new Vector2(parent_size.x * RelativePosition.x, parent_size.y * RelativePosition.y);
		sprite.ViewNormalizedPosition = parent_pos + offset;
	}
}
