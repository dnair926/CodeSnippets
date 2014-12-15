using System;
using System.Collections.Generic;
using System.Diagnostics;
using CodeSnippets.Samples.IDisposable;

namespace CodeSnippets.Samples {
	class Program {
		static void Main(string[] args) {

			using (Animal animal = new Animal()) {
				SetAnimalFeatures(animal);
				animal.Speak();
			}

			using (Dog dog = new Dog()) {
				SetAnimalFeatures(dog);
				dog.Tricks = new List<string>() { "Sit", "Walk" };
				dog.Speak();
			}

			Console.Read();
		}

		private static void SetAnimalFeatures(Animal animal) {
			const int maxSize = 10000;
			animal.Name = "Jack";
			animal.Pictures = new List<string>(maxSize);

			for (int i = 0; i < maxSize; i++) {
				animal.Pictures.Add(string.Format("images/image{0}.png", i));
			}
		}
	}
}