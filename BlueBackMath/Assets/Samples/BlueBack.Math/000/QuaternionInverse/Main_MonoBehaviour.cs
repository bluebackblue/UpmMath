

/** BlueBack.Math.Samples.QuaternionInverse
*/
#if(!DEF_BLUEBACK_MATH_SAMPLES_DISABLE)
namespace BlueBack.Math.Samples.QuaternionInverse
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** random
		*/
		private Unity.Mathematics.Random random;

		/** quaternion
		*/
		public Unity.Mathematics.quaternion quaternion_1;
		public Unity.Mathematics.quaternion quaternion_2;

		/** distance
		*/
		public Unity.Mathematics.float4 distance;

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
			Unity.Mathematics.quaternion t_quaternion = Unity.Mathematics.quaternion.identity;
			t_quaternion = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.up,this.random.NextFloat(0.0f,6.28f)),t_quaternion);
			t_quaternion = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.left,this.random.NextFloat(0.0f,6.28f)),t_quaternion);
			t_quaternion = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.forward,this.random.NextFloat(0.0f,6.28f)),t_quaternion);

			//UnityEngine.Quaternion.Inverse
			this.quaternion_1 = UnityEngine.Quaternion.Inverse(t_quaternion);

			//BlueBack.Math.Quaternion.Inverse
			this.quaternion_2 = BlueBack.Math.Quaternion.Inverse(in t_quaternion);

			//distance
			this.distance = BlueBack.Math.Float4.CutEpsilon(this.quaternion_1.value - this.quaternion_2.value);
		}
	}
}
#endif

