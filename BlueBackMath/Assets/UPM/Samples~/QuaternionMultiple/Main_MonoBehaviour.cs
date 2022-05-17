

/** BlueBack.Math.Samples.QuaternionMultiple
*/
#if(!DEF_BLUEBACK_MATH_SAMPLES_DISABLE)
namespace BlueBack.Math.Samples.QuaternionMultiple
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
			Unity.Mathematics.quaternion t_quaternion_1 = Unity.Mathematics.quaternion.identity;
			t_quaternion_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.up,this.random.NextFloat(0.0f,6.28f)),t_quaternion_1);
			t_quaternion_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.left,this.random.NextFloat(0.0f,6.28f)),t_quaternion_1);
			t_quaternion_1 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.forward,this.random.NextFloat(0.0f,6.28f)),t_quaternion_1);

			Unity.Mathematics.quaternion t_quaternion_2 = Unity.Mathematics.quaternion.identity;
			t_quaternion_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.up,this.random.NextFloat(0.0f,6.28f)),t_quaternion_2);
			t_quaternion_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.left,this.random.NextFloat(0.0f,6.28f)),t_quaternion_2);
			t_quaternion_2 = Unity.Mathematics.math.mul(Unity.Mathematics.quaternion.AxisAngle(UnityEngine.Vector3.forward,this.random.NextFloat(0.0f,6.28f)),t_quaternion_2);

			//Unity.Mathematics.math.mul
			this.quaternion_1 = Unity.Mathematics.math.mul(t_quaternion_1,t_quaternion_2);

			//BlueBack.Math.Quaternion.Multiple
			this.quaternion_2 = BlueBack.Math.Quaternion.Multiple(in t_quaternion_1,in t_quaternion_2);

			//distance
			this.distance = BlueBack.Math.Float4.CutEpsilon(this.quaternion_1.value - this.quaternion_2.value);
		}
	}
}
#endif

