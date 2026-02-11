using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;
public enum BallType
{
    Футбольный, Баскетбольный, Волейбольный
}

public class Ball
{
	private BallType _type;
	private double _diameter;
	private double _weight;
	private double _pressure;
	private string _material;

	public Ball(BallType type, double diameter, double weight, double pressure, string material)
	{
		Тип = type;
		Диаметр = diameter;
		Вес = weight;
		Давление = pressure;
		Материал = material;
	}

	public BallType Тип
	{
		get => _type;
		set => _type = value;
	}

	public double Диаметр
	{
		get => _diameter;
		set
		{
			if (value <= 0)
				throw new ArgumentException("Диаметр должен быть больше нуля.");
			_diameter = value;
		}
	}

	public double Вес
	{
		get => _weight;
		set
		{
			if (value <= 0)
				throw new ArgumentException("Вес должен быть больше нуля.");
			_weight = value;
		}
	}

	public double Давление
	{
		get => _pressure;
		set
		{
			if (value < 0)
				throw new ArgumentException("Давление не может быть отрицательным.");
			_pressure = value;
		}
	}

	public string Материал
	{
		get => _material;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Материал не может быть пустым.");
			_material = value.Trim();
		}
	}

	public void Накачать(double добавитьАтм)
	{
		if (добавитьАтм < 0)
			throw new ArgumentException("Нельзя накачать на отрицательную величину.");

		Давление += добавитьАтм;
		Console.WriteLine($"Накачано на {добавитьАтм:F2} атм. Текущее давление: {Давление:F2} атм");
	}

	public void Спустить(double спуститьАтм)
	{
		if (спуститьАтм < 0)
			throw new ArgumentException("Нельзя спустить на отрицательную величину.");

		Давление = Math.Max(0, Давление - спуститьАтм);
		Console.WriteLine($"Спущено {спуститьАтм:F2} атм. Осталось: {Давление:F2} атм");
	}

	public void НакачатьНесколькоРаз(params double[] значения)
	{
		Console.WriteLine($"\nНакачка несколькими порциями ({значения.Length} шт.):");
		foreach (double v in значения)
		{
			Накачать(v);
		}
	}

	public bool ПроверитьНаИзнос(out string причина)
	{
		причина = "";

		if (Давление < 0.4)
		{
			причина = "слишком низкое давление";
			return true;
		}

		if (Материал.Contains("дыр") ||
			Материал.Contains("тёрт") ||
			Материал.Contains("трес"))
		{
			причина = "повреждённый материал";
			return true;
		}

		if (Давление > 2.8)
		{
			причина = "перекачка — риск взрыва";
			return true;
		}

		причина = "в норме";
		return false;
	}

	public override string ToString()
	{
		return $"Мяч: {Тип}, D={Диаметр} см, вес={Вес} г, давление={Давление:F2} атм, материал='{Материал}'";
	}
}