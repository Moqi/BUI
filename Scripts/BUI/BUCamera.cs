using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
[RequireComponent (typeof(Camera))]
public class BUCamera : MonoBehaviour
{
	public static BUCamera CurrentCamera = null;
	
	void Awake()
	{
		if (CurrentCamera != null)
		{
			Debug.Log("BUCamera already exists.");
			gameObject.SetActive(false);
			return;
		}
		CurrentCamera = this;
	}

	void Update()
	{
		if (CurrentCamera == null)
		{
			CurrentCamera = this;
		}
	}

	public Vector2 PixelWindowSize
	{
		get
		{
			return new Vector2(camera.pixelWidth, camera.pixelHeight);
		}
	}

	public Vector2 AbsoluteWindowSize
	{
		get
		{
			return new Vector2(camera.aspect * 2.0f, 2.0f);
		}
	}

	public float WindowAspectRatio
	{
		get
		{
			return camera.aspect;
		}
	}

	/// <summary>
	/// Calculates the relative position. 
	/// [0.0, 1.0]
	/// </summary>
	/// <returns>The relative position.</returns>
	/// <param name="absolute_position">Absolute_position.</param>
	public Vector2 CalculateRelativePosition(Vector2 absolute_position)
	{
		var x = ((absolute_position.x / camera.aspect) + 1.0f) * 0.5f;
		var y = (absolute_position.y + 1.0f) * 0.5f;
		return new Vector2(x, y);
	}

	/// <summary>
	/// Calculates the absolute position.
	/// x:[-aspect, +aspect]
	/// y:[-1.0, +1.0]
	/// </summary>
	/// <returns>The absolute position.</returns>
	/// <param name="relative_position">Relative_position.</param>
	public Vector2 CalculateAbsolutePosition(Vector2 relative_position)
	{
		var x = (relative_position.x * 2.0f - 1.0f) * camera.aspect;
		var y = relative_position.y * 2.0f - 1.0f;
		return new Vector2(x, y);
	}
}
