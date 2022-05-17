

/** BlueBack.Math.Samples.QuaternionMultiplePoint
*/
#if(!DEF_BLUEBACK_MATH_SAMPLES_DISABLE)
namespace BlueBack.Math.Samples.QuaternionMultiplePoint
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** random
		*/
		private Unity.Mathematics.Random random;

		/** point
		*/
		public Unity.Mathematics.float3 point_1;
		public Unity.Mathematics.float3 point_2;

		/** distance
		*/
		public Unity.Mathematics.float3 distance;

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

			Unity.Mathematics.float3 t_point = new Unity.Mathematics.float3(this.random.NextFloat(-10.0f,10.0f),this.random.NextFloat(-10.0f,10.0f),this.random.NextFloat(-10.0f,10.0f));

			//Unity.Mathematics.math.mul
			this.point_1 = Unity.Mathematics.math.mul(t_quaternion_1,t_point);

			//BlueBack.Math.Quaternion.Multiple
			this.point_2 = BlueBack.Math.Quaternion.Multiple(in t_quaternion_1,in t_point);

			//distance
			this.distance = BlueBack.Math.Float3.CutEpsilon(this.point_1 - this.point_2);
		}
	}
}
#endif

