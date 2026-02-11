using System;
using ConsoleApp1;
using Microsoft.VisualBasic;

class Program
{
	static void Main()
	{
		Ball мяч = new Ball(
			BallType.Футбольный,
			diameter: 22.0,
			weight: 430.0,
			pressure: 0.7,
			material: "кожа"
		);

		Console.WriteLine("Создан мяч:");
		Console.WriteLine(мяч);

		мяч.Накачать(0.5);
		мяч.Спустить(0.1);

		мяч.НакачатьНесколькоРаз(0.3, 0.2, 0.1);

		if (мяч.ПроверитьНаИзнос(out string причина))
			Console.WriteLine($"\nИзнос обнаружен: {причина}");
		else
			Console.WriteLine($"\nИзнос не обнаружен: {причина}");

		мяч.Материал = "хорошая кожа";
		Console.WriteLine($"\nОбновлён материал: '{мяч.Материал}'");
		if (мяч.ПроверитьНаИзнос(out причина))
			Console.WriteLine($"\nТеперь: {причина}");

		Console.WriteLine("\nГотово! Все требования выполнены.");
	}
}