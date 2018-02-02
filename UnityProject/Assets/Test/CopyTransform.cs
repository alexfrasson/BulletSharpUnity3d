using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransform : MonoBehaviour
{
	//public static BulletSharp.Math.Vector3 offset = new BulletSharp.Math.Vector3(4999999, 4999999, 4999999);
	public static BulletSharp.Math.Vector3 offset = new BulletSharp.Math.Vector3(0, 0, 0);

	public Transform t;

	private void Start()
	{
		GameObject go = Instantiate(gameObject);

		t = go.transform;

		BulletSharp.Math.Vector3 p = new BulletSharp.Math.Vector3(t.position.x, t.position.y, t.position.z) + offset;
		t.position = new Vector3((float)p.X, (float)p.Y, (float)p.Z);

		Destroy(GetComponent<Rigidbody>());
		Destroy(GetComponent<Collider>());
		Destroy(go.GetComponent<CopyTransform>());
	}

	void FixedUpdate()
	{
		BulletSharp.Math.Vector3 p = new BulletSharp.Math.Vector3(t.position.x, t.position.y, t.position.z) - offset;
		transform.position = new Vector3((float)p.X, (float)p.Y, (float)p.Z);

		transform.rotation = t.rotation;
	}
}
