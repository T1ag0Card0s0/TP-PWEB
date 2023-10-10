package org.example;

import org.junit.Test;

import static org.junit.Assert.*;

public class CalculatorTest {
	Calculator c = new Calculator();

	@Test
	public void add() {
		assertEquals(3,c.add(1,2));
		assertEquals(5,c.add(-1,6));
		assertEquals(0,c.add(0,0));
		assertEquals(0,c.add(-5000,5000));
		assertEquals(-1,c.add(1,-2));
		assertEquals(1,c.add(1,0));
	}

	@Test
	public void subtract() {
		assertEquals(5, c.subtract(10,5));
		assertEquals(0, c.subtract(10,10));
		assertEquals(-999, c.subtract(0,999));
	}

	@Test
	public void multiply() {
		assertEquals(25, c.multiply(5,5));
		assertEquals(-1, c.multiply(1,-1));
	}

	@Test
	public void sqrt() {
		assertEquals(9, c.sqrt(81), 0.01);
		assertEquals(3, c.sqrt(9), 0.01);
	}

	@Test
	public void fact() {
		assertEquals(120, c.fact(5));
	}
}