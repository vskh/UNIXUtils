using System.Reflection;
using System.Runtime.InteropServices;
using CommandLine;

// Управление общими сведениями о сборке осуществляется с помощью 
// набора атрибутов. Измените значения этих атрибутов, чтобы изменить сведения,
// связанные со сборкой.
[assembly: AssemblyTitle("cat")]
[assembly: AssemblyDescription("Concatenate files and print result to console")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("khondar.name")]
[assembly: AssemblyProduct("cat")]
[assembly: AssemblyCopyright("Copyright © 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyLicense("This is free software." +
	" You may redistribute copies of it under the terms of the MIT License" +
   	" <http://www.opensource.org/licenses/mit-license.php>.\n")]
[assembly: AssemblyUsage("Usage: cat [options]... [files]...\n" +
                         "Concatenate given files (or take content of stardard input if none given)" +
                         " and print it to console.")]

// Параметр ComVisible со значением FALSE делает типы в сборке невидимыми 
// для COM-компонентов.  Если требуется обратиться к типу в этой сборке через 
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("89db8a7b-7352-4a19-9868-13da7276a553")]

// Сведения о версии сборки состоят из следующих четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии 
//   Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]