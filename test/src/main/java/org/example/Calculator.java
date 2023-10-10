package org.example;

public class Calculator {
	public Calculator() {	}
	public int add(int val1, int val2){
		return val1 + val2;
	}

	public int subtract(int val1, int val2){
		return val1 - val2;
	}

	public int multiply(int val1, int val2){
		return val1 * val2;
	}

	public double sqrt(int val){
		return Math.sqrt(val);
	}

	public int fact(int val){
		int fact=1;
		for(int i = 1; i <= val; i++){
			fact=fact*i;
		}

		return fact;
	}
}
