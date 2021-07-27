using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDSVisualizer : MonoBehaviour
{
	[SerializeField] private float minRadius = 1, maxRadius = 1.5f;
	[SerializeField] private Vector2 regionSize = Vector2.one;
	[SerializeField] private int rejectionSamples = 20;
	[SerializeField] private float displayRadius = 1;
	[SerializeField] private Vector3 regionOffset = Vector3.one;
	[SerializeField] private float invalidRadius = 5, invalidTargetRadius = 5;

	private List<Vector2> points;

	void OnValidate()
	{
		points = PoissonDiscSampler.SamplePoissonDiscPositions(minRadius, maxRadius, regionSize, rejectionSamples);
	}

#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(new Vector3(regionOffset.x + regionSize.x / 2, regionOffset.y, regionOffset.z + regionSize.y / 2), new Vector3(regionSize.x, 0, regionSize.y));
		if (points.Count > 0)
		{
			foreach (Vector2 point in points)
			{
				Vector3 pointPos = new Vector3(regionOffset.x + point.x, 0, regionOffset.z + point.y);
				if ((pointPos - transform.position).sqrMagnitude > invalidRadius * invalidRadius)
				{
					Gizmos.color = Color.grey;
					if ((pointPos - transform.position).sqrMagnitude > invalidTargetRadius * invalidTargetRadius)
					{
						Gizmos.color = Color.green;
					}
					else
					{
						Gizmos.color = Color.red;
					}
					Gizmos.DrawSphere(new Vector3(regionOffset.x + point.x, regionOffset.y, regionOffset.z + point.y), displayRadius);
				}
			}
		}
	}
#endif
}
