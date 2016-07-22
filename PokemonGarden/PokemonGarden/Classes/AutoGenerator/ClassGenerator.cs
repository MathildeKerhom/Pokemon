using System;
using System.Collections.Generic;
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
		Name,
		LastName,
		Description,
		FullName,
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
			Dictionary<String, Object> itemProperties = Reflectionner.ReadClass<T>();
			T result = new T();

			if (inheritance > 0)
			{
				inheritance--;

				foreach (var item in itemProperties)
				{
					PropertyInfo property = typeof(T).GetProperty(item.Key);
					if (property.CanWrite && property.GetSetMethod(true).IsPublic)
					{
						int? specificFakerType = (int?)property.CustomAttributes?.Where(x => x.AttributeType.Name.Equals(nameof(FakerTyper)))?.FirstOrDefault()?.ConstructorArguments.FirstOrDefault().Value;
						switch (specificFakerType) // select ctor parameter of FakerTyper attribut element
						{
							case (int)SpecificFakerType.IGNORE:
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
											case (int)SpecificFakerType.Name:
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
										property.SetValue(result, runGenerator(inheritance, generatorMethode));
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

		public static List<T> GenerateListItems(int inheritance = 2)
		{
			List<T> result = new List<T>();
			MethodInfo generatorMethode = typeof(ClassGenerator<T>).GetMethod("GenerateItem");
			for (int i = 0; i < Faker.RandomNumber.Next(0, 100); i++)
			{
				result.Add((T)runGenerator(inheritance, generatorMethode));
			}
			return result;
		}

		private static object generateNewObject(int inheritance, Type type)
		{
			ConstructorInfo[] constructors = type.GetConstructors();
			foreach (ConstructorInfo constructor in constructors)
			{
				if (constructor.GetParameters().Length == 0) // accepte no arguments
				{
					Type staticType = typeof(ClassGenerator<>).MakeGenericType(new Type[] { type });
					MethodInfo generatorMethode = staticType.GetMethod("GenerateItem");
					object resultGen = runGenerator(inheritance, generatorMethode);
					return resultGen;
				}
			}
			return null; // can't build valide object ==> no ctor()
		}

		/// <summary>
		/// return result of generator methode
		/// </summary>
		/// <param name="inheritance"></param>
		/// <param name="generatorMethode"></param>
		/// <returns></returns>
		private static object runGenerator(int inheritance, MethodInfo generatorMethode)
		{
			return generatorMethode.Invoke(generatorMethode, new object[] { inheritance });
		}
	}
}
