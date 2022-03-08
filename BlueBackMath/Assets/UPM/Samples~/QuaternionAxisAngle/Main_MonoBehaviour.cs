

/** BlueBack.Math.Samples.QuaternionAxisAngle
*/
namespace BlueBack.Math.Samples.QuaternionAxisAngle
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
			Unity.Mathematics.float3 t_axis = Unity.Mathematics.math.normalize(new Unity.Mathematics.float3(this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f)));
			float t_radian = this.random.NextFloat(0.0f,6.28f);

			//Unity.Mathematics.quaternion.AxisAngle
			this.quaternion_1 = Unity.Mathematics.quaternion.AxisAngle(t_axis,t_radian);

			//BlueBack.Math.Quaternion.AxisAngle
			this.quaternion_2 = BlueBack.Math.Quaternion.AxisAngle(t_axis,t_radian);

			//distance
			this.distance = BlueBack.Math.Float4.CutEpsilon(this.quaternion_1.value - this.quaternion_2.value);
		}
	}
}

