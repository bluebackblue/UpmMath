

/** BlueBack.Math.Samples.Fload3CrossDotTheta
*/
namespace BlueBack.Math.Samples.Fload3CrossDotTheta
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** random
		*/
		private Unity.Mathematics.Random random;

		/** theta
		*/
		public float theta;
		public float theta_dot;
		public float theta_cross;

		/** gameobject
		*/
		public UnityEngine.GameObject gameobjet_1;
		public UnityEngine.GameObject gameobjet_2;
		public UnityEngine.GameObject gameobjet_cross;

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
			Unity.Mathematics.float3 t_float3_1 = new Unity.Mathematics.float3(0.0f,0.0f,1.0f);

			this.theta = (UnityEngine.Time.time % 6.28f) - 3.14f;

			Unity.Mathematics.quaternion t_quaternion = Unity.Mathematics.quaternion.AxisAngle(new Unity.Mathematics.float3(0.0f,1.0f,0.0f),this.theta);
			Unity.Mathematics.float3 t_float3_2 = Unity.Mathematics.math.mul(t_quaternion,t_float3_1);

			float t_dot = BlueBack.Math.Float3.Dot(t_float3_1,t_float3_2);
			this.theta_dot = Unity.Mathematics.math.acos(t_dot);

			Unity.Mathematics.float3 t_cross = BlueBack.Math.Float3.Cross(t_float3_1,t_float3_2);
			this.theta_cross = Unity.Mathematics.math.asin(Unity.Mathematics.math.length(t_cross));

			float t_scale_rate = 5.0f;

			this.gameobjet_1.transform.forward = t_float3_1;
			this.gameobjet_1.transform.localScale = new UnityEngine.Vector3(0.1f,0.1f,t_scale_rate);
			this.gameobjet_1.transform.position = t_float3_1 * t_scale_rate * 0.5f;

			this.gameobjet_2.transform.forward = t_float3_2;
			this.gameobjet_2.transform.localScale = new UnityEngine.Vector3(0.1f,0.1f,t_scale_rate);
			this.gameobjet_2.transform.position = t_float3_2 * t_scale_rate * 0.5f;

			float t_cross_length = Unity.Mathematics.math.length(t_cross);
			Unity.Mathematics.float3 t_cross_normalize = Unity.Mathematics.math.normalize(t_cross);
			this.gameobjet_cross.transform.forward = t_cross_normalize;
			this.gameobjet_cross.transform.localScale = new UnityEngine.Vector3(0.1f,0.1f,t_cross_length * t_scale_rate);
			this.gameobjet_cross.transform.position = t_cross_normalize * t_cross_length * t_scale_rate * 0.5f;
		}
	}
}

