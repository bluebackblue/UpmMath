

/** BlueBack.Math.Samples.QuaternionLookRotation
*/
#if(!DEF_BLUEBACK_MATH_SAMPLES_DISABLE)
namespace BlueBack.Math.Samples.QuaternionLookRotation
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

		/** forward
		*/
		public Unity.Mathematics.float3 forward_true;
		public Unity.Mathematics.float3 forward_1;
		public Unity.Mathematics.float3 forward_2;

		/** up
		*/
		public Unity.Mathematics.float3 up_1;
		public Unity.Mathematics.float3 up_2;

		/** distance
		*/
		public Unity.Mathematics.float3 distance_forward;
		public Unity.Mathematics.float3 distance_up;

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
			this.forward_true = Unity.Mathematics.math.normalize(new Unity.Mathematics.float3(this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f)));
			Unity.Mathematics.float3 t_up = Unity.Mathematics.math.normalize(new Unity.Mathematics.float3(this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f),this.random.NextFloat(-1.0f,1.0f)));

			float t_dot = Unity.Mathematics.math.dot(this.forward_true,t_up);
			if(t_dot != 0.0f){

				//Unity.Mathematics.math.mul
				this.quaternion_1 = Unity.Mathematics.quaternion.LookRotation(this.forward_true,t_up);
				this.forward_1 = Unity.Mathematics.math.mul(this.quaternion_1,new Unity.Mathematics.float3(0.0f,0.0f,1.0f));
				this.up_1 = Unity.Mathematics.math.mul(this.quaternion_1,new Unity.Mathematics.float3(0.0f,1.0f,0.0f));

				//BlueBack.Math.Quaternion.LookRotation
				this.quaternion_2 = BlueBack.Math.Quaternion.LookRotation(in this.forward_true,in t_up);
				this.forward_2 = Unity.Mathematics.math.mul(this.quaternion_2,new Unity.Mathematics.float3(0.0f,0.0f,1.0f));
				this.up_2= Unity.Mathematics.math.mul(this.quaternion_2,new Unity.Mathematics.float3(0.0f,1.0f,0.0f));

				//distance
				this.distance_forward = BlueBack.Math.Float3.CutEpsilon(this.forward_1 - this.forward_2);
				this.distance_up = BlueBack.Math.Float3.CutEpsilon(this.up_1 - this.up_2);

				if(Unity.Mathematics.math.length(this.distance_forward) != 0.0f){
					UnityEditor.EditorApplication.isPaused = true;
				}
				if(Unity.Mathematics.math.length(this.distance_up) != 0.0f){
					UnityEditor.EditorApplication.isPaused = true;
				}
			}
		}
	}
}
#endif

