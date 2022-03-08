

/** BlueBack.Math.Samples.Rotation
*/
namespace BlueBack.Math.Samples.Rotation
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** random
		*/
		private Unity.Mathematics.Random random;

		/** distance
		*/
		public float distance;

		/** Awake
		*/
		private void Awake()
		{
			this.random = new Unity.Mathematics.Random((uint)System.DateTime.Now.Millisecond);
		}

		/** Update
        */
		private void Update()
		{
			Unity.Mathematics.quaternion t_1 = Unity.Mathematics.quaternion.identity;
			t_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.up,this.random.NextFloat(0.0f,6.28f)),t_1);
			t_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.left,this.random.NextFloat(0.0f,6.28f)),t_1);
			t_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.forward,this.random.NextFloat(0.0f,6.28f)),t_1);

			Unity.Mathematics.quaternion t_2 = Unity.Mathematics.quaternion.identity;
			t_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.up,this.random.NextFloat(0.0f,6.28f)),t_2);
			t_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.left,this.random.NextFloat(0.0f,6.28f)),t_2);
			t_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.forward,this.random.NextFloat(0.0f,6.28f)),t_2);

			//UnityEngine.Quaternion.Dot
			float t_dot_1 = UnityEngine.Quaternion.Dot(t_1,t_2);

			//BlueBack.Math.Quaternion.Dot
			float t_dot_2 = BlueBack.Math.Quaternion.Dot(in t_1,in t_2);

			this.distance = t_dot_1 - t_dot_2;
		}
	}
}

