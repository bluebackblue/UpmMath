

/** BlueBack.Math.Samples.Float3Dot
*/
#if(!DEF_BLUEBACK_MATH_SAMPLES_DISABLE)
namespace BlueBack.Math.Samples.Float3Dot
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
			Unity.Mathematics.float3 t_float3_1 = new Unity.Mathematics.float3(this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f));
			Unity.Mathematics.float3 t_float3_2 = new Unity.Mathematics.float3(this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f));

			//UnityEngine.Vector3.Dot
			this.dot_1 = UnityEngine.Vector3.Dot(t_float3_1,t_float3_2);

			//BlueBack.Math.Float3.Dot
			this.dot_2 = BlueBack.Math.Float3.Dot(in t_float3_1,in t_float3_2);

			//distance
			this.distance = this.dot_1 - this.dot_2;
		}
	}
}
#endif

