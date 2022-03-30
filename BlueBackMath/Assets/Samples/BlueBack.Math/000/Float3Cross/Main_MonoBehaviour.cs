

/** BlueBack.Math.Samples.Float3Cross
*/
namespace BlueBack.Math.Samples.Float3Cross
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** random
		*/
		private Unity.Mathematics.Random random;

		/** cross
		*/
		public Unity.Mathematics.float3 cross_1;
		public Unity.Mathematics.float3 cross_2;

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
			Unity.Mathematics.float3 t_float3_1 = new Unity.Mathematics.float3(this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f));
			Unity.Mathematics.float3 t_float3_2 = new Unity.Mathematics.float3(this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f));

			//UnityEngine.Vector3.Cross
			this.cross_1 = UnityEngine.Vector3.Cross(t_float3_1,t_float3_2);

			//BlueBack.Math.Float3.Cross
			this.cross_2 = BlueBack.Math.Float3.Cross(in t_float3_1,in t_float3_2);

			//distance
			this.distance = BlueBack.Math.Float3.CutEpsilon(this.cross_1 - this.cross_2);
		}
	}
}

