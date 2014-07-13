using System;
using System.Collections;

public class Randomizer {

	public static float Next(){
		Random random = new Random();
		return (float)random.NextDouble();
	}

	public static int NextInt(int max){
		Random random = new Random();
		return (int)(random.NextDouble() * max);
	}

	public static double NextDouble(double max){
		Random random = new Random();
		return (random.NextDouble() * max);
	}

	public static double NextFloat(float max){
		Random random = new Random();
		return (random.NextDouble() * max);
	}

	public static float NextCenterFloat(double max){
		Random random = new Random();
		return (float)((random.NextDouble()-.5f) * max);
	}
}
