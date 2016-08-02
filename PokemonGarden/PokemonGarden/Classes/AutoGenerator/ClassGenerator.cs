using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PokemonGarden.Classes.AutoGenerator.Attributs;

namespace PokemonGarden.Classes.AutoGenerator
{
	public enum SpecificFakerType
	{
		IGNORE,
		FirstName,
		LastName,
		Description,
		FullName,
		ListItemMin1Max2,
		ElementType,
		PokemonImg,
	}

	public static class ClassGenerator<T> where T : class, new()
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inheritance"></param>
		/// <returns></returns>
		public static T GenerateItem(Int32 inheritance = 2)
		{
			List<String> itemsPropertiesName = Reflectionner.ReadClassProperties<T>();
			T result = new T();

			if (inheritance > 0)
			{
				inheritance--;

				foreach (var itemName in itemsPropertiesName)
				{
					PropertyInfo property = typeof(T).GetProperty(itemName);
					if (property.CanWrite && property.SetMethod.IsPublic)
					{
						int? specificFakerType = (int?)property.CustomAttributes?.Where(x => x.AttributeType.Name.Equals(nameof(FakerTyper)))?.FirstOrDefault()?.ConstructorArguments.FirstOrDefault().Value;
						switch (specificFakerType) // select ctor parameter of FakerTyper attribut element
						{
							case (int)SpecificFakerType.IGNORE:
								break;
							case (int)SpecificFakerType.ElementType:
								property.SetValue(result, (ElementType)Faker.RandomNumber.Next(Enum.GetValues(typeof(ElementType)).Length - 1));
								break;
							case (int)SpecificFakerType.PokemonImg:
								property.SetValue(result, new Uri(Faker.RoboHash.Image()));
								break;
							default:
								switch (property.PropertyType.Name)
								{
									case "Boolean":
										break;
									case "Int32":
										property.SetValue(result, Faker.RandomNumber.Next(Int32.MaxValue));
										break;
									case "int":
										property.SetValue(result, Faker.RandomNumber.Next(Int32.MaxValue));
										break;
									case "String":
										switch (specificFakerType)
										{
											case (int)SpecificFakerType.FirstName:
												property.SetValue(result, Faker.Name.First());
												break;
											case (int)SpecificFakerType.LastName:
												property.SetValue(result, Faker.Name.Last());
												break;
											case (int)SpecificFakerType.Description:
												property.SetValue(result, Faker.Lorem.Paragraph());
												break;
											case (int)SpecificFakerType.FullName:
												property.SetValue(result, Faker.Name.FullName());
												break;
											default:
												property.SetValue(result, Faker.Lorem.Sentence());
												break;
										}
										break;
									case "List`1":
										Type staticType = typeof(ClassGenerator<>).MakeGenericType(property.PropertyType.GetGenericArguments());
										MethodInfo generatorMethode = staticType.GetMethod("GenerateListItems");
										switch (specificFakerType)
										{
											case (int)SpecificFakerType.ListItemMin1Max2:
													property.SetValue(result, runGenerator(generatorMethode, new object[] { inheritance, 1, 2 }));
												break;
											default:
												property.SetValue(result, runGenerator(generatorMethode, new object[] { inheritance, 0, 100 }));
												break;
										}
										break;
									default:
										property.SetValue(result, generateNewObject(inheritance, property.PropertyType));
										break;
								}
								break;
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// generate list of object
		/// </summary>
		/// <param name="inheritance">remaning inheritance</param>
		/// <param name="minItems">min list item</param>
		/// <param name="maxItems">max list item</param>
		/// <returns></returns>
		public static List<T> GenerateListItems(int inheritance = 2, int minItems = 0, int maxItems = 100)
		{
			List<T> result = new List<T>();
			MethodInfo generatorMethode = typeof(ClassGenerator<T>).GetMethod("GenerateItem");
			for (int i = 0; i < new Random(DateTime.Now.Millisecond).Next(minItems, maxItems + 1); i++)
			{
				result.Add((T)runGenerator(generatorMethode, new object[] { inheritance }));
			}
			return result;
		}

		/// <summary>
		/// generate new object from type of object
		/// </summary>
		/// <param name="inheritance">remaning inheritance</param>
		/// <param name="type">type to build</param>
		/// <returns></returns>
		private static object generateNewObject(int inheritance, Type type)
		{
			ConstructorInfo[] constructors = type.GetConstructors();
			foreach (ConstructorInfo constructor in constructors)
			{
				if (constructor.GetParameters().Length == 0) // accepte no arguments
				{
					Type staticType = typeof(ClassGenerator<>).MakeGenericType(new Type[] { type });
					MethodInfo generatorMethode = staticType.GetMethod("GenerateItem");
					object resultGen = runGenerator(generatorMethode, new object[] { inheritance });
					return resultGen;
				}
			}
			return null; // can't build valide object ==> no ctor()
		}

		/// <summary>
		/// return result of invoke methode
		/// </summary>
		/// <param name="generatorMethode">execute methode</param>
		/// <param name="parameters">parameters of methode</param>
		/// <returns></returns>
		private static object runGenerator(MethodInfo generatorMethode, object[] parameters)
		{
			return generatorMethode.Invoke(generatorMethode, parameters);
		}
	}
}
