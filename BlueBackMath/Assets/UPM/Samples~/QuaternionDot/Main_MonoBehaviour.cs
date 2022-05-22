

/** BlueBack.Math.Samples.QuaternionDot
*/
#if(!DEF_BLUEBACK_MATH_SAMPLES_DISABLE)
namespace BlueBack.Math.Samples.QuaternionDot
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** random
		*/
		private Unity.Mathematics.Random random;

		/** dot
		*/
		public float dot_1;
		public float dot_2;

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
			Unity.Mathematics.quaternion t_quaternion_1 = Unity.Mathematics.quaternion.identity;
			t_quaternion_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.up,this.random.NextFloat(0.0f,6.28f)),t_quaternion_1);
			t_quaternion_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.left,this.random.NextFloat(0.0f,6.28f)),t_quaternion_1);
			t_quaternion_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.forward,this.random.NextFloat(0.0f,6.28f)),t_quaternion_1);

			Unity.Mathematics.quaternion t_quaternion_2 = Unity.Mathematics.quaternion.identity;
			t_quaternion_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.up,this.random.NextFloat(0.0f,6.28f)),t_quaternion_2);
			t_quaternion_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.left,this.random.NextFloat(0.0f,6.28f)),t_quaternion_2);
			t_quaternion_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.forward,this.random.NextFloat(0.0f,6.28f)),t_quaternion_2);

			//UnityEngine.Quaternion.Dot
			this.dot_1 = UnityEngine.Quaternion.Dot(t_quaternion_1,t_quaternion_2);

			//BlueBack.Math.Quaternion.Dot
			this.dot_2 = BlueBack.Math.Quaternion.Dot(in t_quaternion_1,in t_quaternion_2);

			//distance
			this.distance = this.dot_1 - this.dot_2;
		}
	}
}
#endif

