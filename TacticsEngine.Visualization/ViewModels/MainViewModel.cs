using System;
using System.Collections.ObjectModel;
using System.Reflection;

using CaptainCoder.TacticsEngine.Board;

namespace TacticsEngine.Visualization.ViewModels;

public class MainViewModel : ViewModelBase
{
    public static string Greeting => "This is Captain Coder's TacticsEngine!";

    private Type? _selectedType;
    public Type? SelectedType
    {
        get => _selectedType;
        set
        {
            SetProperty(ref _selectedType, value);
            GetSelectedTypeDetails();
        }
    }

    #region ObservableCollections
    public ObservableCollection<Type> ReflectionTypes { get; set; } = [];
    public ObservableCollection<MethodInfo> Methods { get; set; } = [];
    public ObservableCollection<FieldInfo> Fields { get; set; } = [];
    public ObservableCollection<MemberInfo> Members { get; set; } = [];
    #endregion

    public MainViewModel()
    {
        GetClasses();
    }

    private void GetClasses()
    {
        ReflectionTypes.Clear();
        Assembly? assembly = Assembly.GetAssembly(typeof(Board));
        if (assembly == null) return;

        foreach (Type type in assembly.GetTypes())
        {
            ReflectionTypes.Add(type);
        }
    }

    private void GetSelectedTypeDetails()
    {
        Methods.Clear();
        Fields.Clear();
        Members.Clear();
        if (SelectedType == null) return;

        foreach (MethodInfo method in SelectedType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Methods.Add(method);
        }
        foreach (FieldInfo field in SelectedType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Fields.Add(field);
        }
        foreach (MemberInfo member in SelectedType.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Members.Add(member);
        }
    }
}
