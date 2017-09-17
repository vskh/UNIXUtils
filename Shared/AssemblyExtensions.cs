using System;
using System.Reflection;

namespace vskh.UNIXUtils.Shared
{
	public static class AssemblyExtensions
	{
		public static T GetAttribute<TAttr, T>(this Assembly assembly, Func<TAttr, T> getProperty)
			where TAttr : Attribute
		{
			if (assembly == null)
			{
				return default(T);
			}

			return getProperty(assembly.GetCustomAttribute<TAttr>());
		}
	}
}